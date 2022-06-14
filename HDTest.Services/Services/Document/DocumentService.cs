using Hangfire;
using HuceDocs.Data.Models;
using HuceDocs.Data.Repository;
using HuceDocs.Notification.Client;
using HuceDocs.Services.Common;
using HuceDocs.Services.EnumDefine;
using HuceDocs.Services.ModelFilter;
using HuceDocs.Services.Service_References;
using HuceDocs.Services.Services;
using HuceDocs.Services.Services.DanhMuc;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.Category;
using HuceDocs.Services.ViewModels.Common;
using HuceDocs.Services.ViewModels.Document;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Z.EntityFramework.Plus;

namespace HuceDocs.Services
{
    public class DocumentService : IDocumentService
    {
        private UnitOfWork work;
        private readonly ILogger<DocumentService> _logger;
        private readonly IUserService _userService;
        private readonly IDanhMucService _danhMucService;
        private readonly IConfiguration _config;
        private readonly INotifyService _notifyService;
        private readonly IFileManagerService _fileManagerService;


        private readonly ExtrConfigModel _extrConfigModel;
        private readonly FCHelper _fchelper;

        private readonly IMessageHub _messageHub;



        public DocumentService(
            ILogger<DocumentService> logger,
            IDanhMucService danhMucService,
            IConfiguration config,
            IUserService userService)
        {
            _logger = logger;
            work = UnitOfWork.GetDefaultInstance();
            _danhMucService = danhMucService;
            _userService = userService;
            _config = config;
            _extrConfigModel = new ExtrConfigModel()
            {
            };
        }


        // get Documents with pagination
        public ApiResult<PagedResult<DocumentVM>> GetDocuments(DocumentFilter filter)
        {
            var query = work.DocumentRepository.Entities
                .Include(o => o.DocumentType)
                .Where(o => o.UserId == filter.UserId)
                .Where(o => o.IsDelete == false);
            if (filter.DocumentTypeId > 0)
                query = query.Where(o => o.DocumentTypeId == filter.DocumentTypeId);
            if (filter.FileName != null)
                query = query.Where(o => o.FileName.Contains(filter.FileName));
            if (filter.Status != null)
                query = query.Where(o => o.Status == filter.Status);
            if (filter.FromDate != null)
                query = query.Where(o => o.CreateDate.Date >= filter.FromDate.Value.Date);
            if (filter.ToDate != null)
                query = query.Where(o => o.CreateDate.Date <= filter.ToDate.Value.Date);
            var data = query.OrderByDescending(o => o.CreateDate)
            .ToList();
            var result = data
                .Skip((filter.PageIndex - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();
            //var x = _mapper.Map<DocumentViewModel>(result.FirstOrDefault());
            var resultVMs = result.Select(o => new DocumentVM
            {
                Id = o.Id,
                CreateDate = o.CreateDate,
                Description = o.Description,
                DocumentTypeId = o.DocumentTypeId,
                FileExtension = o.FileExtension,
                FileLength = o.FileLength,
                FileName = o.FileName,
                FilePath = o.FilePath,
                IsDelete = o.IsDelete,
                Status = o.Status,
                TotalOfFields = o.TotalOfFields,
                TotalOfPages = o.TotalOfPages,
                UserId = o.UserId,
               
                DocumentType = o.DocumentType != null ? new CategoryVM(o.DocumentType) : null
            }).ToList();
            var pagedResult = new PagedResult<DocumentVM>()
            {
                TotalRecords = data.Count,
                PageIndex = filter.PageIndex,
                PageSize = filter.PageSize,
                Items = resultVMs
            };
            return new ApiSuccess<PagedResult<DocumentVM>> { Result = pagedResult };
        }

        public ApiResult<List<Document>> GetDocuments(int userid)
        {
            var data = work.DocumentRepository.NoTrackingEntities
                .Where(o => o.UserId == userid)
                .ToList();
            return new ApiSuccess<List<Document>> { Result = data };
        }

        public async Task<ApiResult<DocumentResultModel>> CreateExtraction(ExtractionRequest request)
        {
            if (request.File == null)
            {
                return new ApiError<DocumentResultModel>("Không nhận được file");
            }

            
            var document = await ExtractionMappingAsync(request);

            document.Status = (int)eDocumentStatus.Prepare;
            document.CreateDate = DateTime.Now;
            document.IsDelete = false;
            try
            {
                var id = work.DocumentRepository.Create(document);
                
                return new ApiSuccess<DocumentResultModel>
                {
                    Result = new DocumentResultModel { Id = id, IsSuccessed = true, FileName = document.FileName }
                };
            }
            catch (Exception e)
            {
                _logger.LogError("CreateDocument FAIL:" + document.FileName + e.Message);
                return new ApiError<DocumentResultModel>
                {
                    Result = new DocumentResultModel { Id = 0, IsSuccessed = false, FileName = document.FileName }
                };
            }
        }

        // Rework
        public async Task<ApiResult<bool>> ReworkAsync(int id, int userId)
        {
            try
            {
                var document = GetById(id, userId).Result;
                if (
                    document.Status != (int)eDocumentStatus.ErrorRead &&
                    document.Status != (int)eDocumentStatus.Failure )
                {
                    _logger.LogInformation("ReworkError_IdDoc=" + document.Id + ":Tài liệu đang ở trạng thái " + eGet.Status(document.Status));
                    return new ApiError<bool>("Tài liệu đang ở trạng thái " + eGet.Status(document.Status));
                }
                work.DocumentRepository.Entities
                    .Where(o => o.Id == id && o.UserId == userId)
                    .Update(o => new Data.Models.Document
                    {
                        Status = (int)eDocumentStatus.Prepare,
                        Description = null
                    });
                // send message to client
                await _messageHub.SendUpdateDocumentStatus(document.UserId, document.Id, (int)eDocumentStatus.Prepare);
                
                return new ApiSuccess<bool>();
            }
            catch (Exception e)
            {
                _logger.LogError("Rework:" + e.Message);
                return new ApiError<bool>();
            }
        }
        public async Task<ApiResult<bool>> UpdateVerifyAsync(int id, string url)
        {
            try
            {
                var document = GetById(id).Result;
                work.DocumentRepository.Entities
                    .Where(o => o.Id == id)
                    .Update(u => new Document { Status = (int)eDocumentStatus.Verify });
                // send message to client
                await _messageHub.SendUpdateDocumentStatus(document.UserId, document.Id, (int)eDocumentStatus.Verify);
                // send notify to admin
                var emails = _config.GetSection("EmailReceiveNotify").GetChildren().ToList();
                var emailSelected = emails.GetRange(new Random().Next(0, emails.Count), 1).FirstOrDefault();

                //var result = "Tài liệu <a href='" + url + "'>" + document.FileName + "</a> đang chờ soát lỗi.";
                //BackgroundJob.Enqueue(() => _emailService.SendEmailNotify(emailSelected.Value, result));

                work.VerifyRepository.Create(new Verify
                {
                    DocumentId = id,
                    Url = url,
                    CreateTime = DateTime.Now,
                    Active = true
                });
                return new ApiSuccess<bool>();
            }
            catch { return new ApiError<bool>(); }
        }


        //public ApiResult<FileVM> GetResultAsJson(string source, Document document)
        //{
        //    //if (document.Type != (int)eDocumentType.Extraction)
        //    //    return new ApiError<FileVM>("Không thể lấy kết quả dạng Json Object");
        //    if (document.Status != (int)eDocumentStatus.Complete)
        //        return new ApiError<FileVM>("Tài liệu đang ở trạng thái " + eGet.Status(document.Status));
        //    //if (document.DocumentType.TypeOfResult == (int)eTypeOfResult.OnlyXlsx)
        //    //    return new ApiErrorResult<FileViewModel>("Không thể lấy kết quả dạng Json Object");

        //    var filePath = "";
        //    var outputs = GetOutputs(document.Id, document.UserId).Result;
        //    if (outputs.Count > 0)
        //    {
        //        string jsonResult = null;
        //        string extension = ".json";
        //        var output = outputs?.FirstOrDefault(o => o.FileExtension.Contains("json", StringComparison.CurrentCulture));
        //        // output có file json
        //        if (output != null)
        //        {
        //            filePath = source + output.FilePath;
        //            jsonResult = System.IO.File.ReadAllText(filePath).Replace("\\u2028", "\\n");
        //            return new ApiSuccess<FileVM>(new FileVM()
        //            {
        //                FileName = document.FileName,
        //                FileData = jsonResult,
        //                FileExtension = extension,
        //                isExtrResult = true
        //            });
        //        }
        //        // không có file json
        //        else
        //        {
        //            filePath = source + outputs.FirstOrDefault().FilePath;
        //            if (Path.GetExtension(filePath).Contains("xml", StringComparison.OrdinalIgnoreCase))
        //            {
        //                XmlDocument doc = new XmlDocument();
        //                doc.Load(filePath);
        //                extension = ".xml";
        //                jsonResult = JsonConvert.SerializeObject(doc).Replace("\\u2028", "\\n");
        //                return new ApiSuccessResult<FileViewModel>(new FileViewModel()
        //                {
        //                    FileName = document.FileName,
        //                    FileData = jsonResult,
        //                    FileExtension = extension,
        //                    isExtrResult = true
        //                });
        //            }
        //            else
        //            {
        //                return new ApiErrorResult<FileViewModel>("Định dạng không hỗ trợ hiển thị");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return new ApiErrorResult<FileViewModel>("Không tìm thấy file kết quả");
        //    }
        //}

        public ApiResult<Document> GetById(int id)
        {
            var result = work.DocumentRepository.Entities

                .Include(k => k.DocumentType)
                .FirstOrDefault(o => o.Id == id);
            return new ApiSuccess<Document> { Result = result };
        }

        public ApiResult<Document> GetById(int id, int userid)
        {
            var result = work.DocumentRepository.Entities
                .Include(k => k.DocumentType)
                .FirstOrDefault(o => o.Id == id && o.UserId == userid);
            if (result == null) return new ApiError<Document>("Không tìm thấy tài liệu");
            return new ApiSuccess<Document> { Result = result };
        }

        public async Task<ApiResult<bool>> ExecuteAsync(int id, int userId)
        {
            try
            {
                var document = work.DocumentRepository.Entities
                .Include(k => k.DocumentType)
                .FirstOrDefault(o => o.Id == id && o.UserId == userId);

                _logger.LogInformation("Document status = " + document.Status + " ID = " + document.Id);
                _logger.LogInformation("Doc status = " + document.Status + " ID = " + document.Id);

                // Execute
                await ExtrExcuteAsync(document);
                return new ApiSuccess<bool>("Tài liệu đang được xử lý");
            }
            catch (Exception)
            {
                _logger.LogError("IdDoc=" + id + "Không thể excute");
                return new ApiError<bool>("Không thể thực hiện file");
            }

        }

        private async Task ExtrExcuteAsync(Document document)
        {
            try
            {
                var extr = new FCHelper(_logger, document);
                if (extr.state)
                {
                    work.DocumentRepository.Entities
                        .Where(o => o.Id == document.Id)
                        .Update(o => new Data.Models.Document()
                        {
                            Status = (int)eDocumentStatus.Processing,
                            Description = null
                        });
                    // send message to client here
                }
                else
                {
                    _logger.LogError("ExtrExcuteError_IdDoc" + document.Id + ": State=" + extr.state);
                    work.DocumentRepository.Entities
                        .Where(o => o.Id == document.Id)
                        .Update(o => new Data.Models.Document()
                        {
                            Status = (int)eDocumentStatus.ErrorRead,
                            Description = "Có lỗi xảy ra"
                        });
                    // create notify to client here
                    await _notifyService.CreateAsync(new Data.Models.Notification
                    {
                        UserId = document.UserId,
                        FileName = document.FileName,
                        DocumentType = document?.DocumentType.Code,
                        CreateDate = DateTime.Now,
                        Status = (int)eNotifyStatus.failure
                    });

                    // send message to client here
                }
            }
            catch (Exception e)
            {
                _logger.LogError("ExtrExecuteError_IdDoc=" + document.Id + ":" + e.Message);
                work.DocumentRepository.Entities
                        .Where(o => o.Id == document.Id)
                        .Update(o => new Data.Models.Document()
                        {
                            Status = (int)eDocumentStatus.ErrorRead,
                            Description = "Đã xảy ra lỗi trong quá trình thực hiện (1.2)"
                        });
                // create notify

                await _notifyService.CreateAsync(new Data.Models.Notification
                {
                    UserId = document.UserId,
                    FileName = document.FileName,
                    DocumentType = document?.DocumentType.Code,
                    CreateDate = DateTime.Now,
                    Status = (int)eNotifyStatus.failure
                });
                // send message to client

            }
        }
        private async Task<List<Document>> MappingAsync(DocumentRequestVM request)
        {
            var results = new List<Document>();
            foreach (var type in request.Types)
            {
                var document = new HuceDocs.Data.Models.Document();

                document.UserId = request.UserId;
                document.DocumentTypeId = request.DocumentTypeId;
                document.FilePath = _fileManagerService.CreateRelativeFilePath(request.UserId, type, (int)eFolder.input, Path.GetExtension(request.File.FileName));
                await _fileManagerService.CreateFile(document.FilePath, request.File);
                document.FileName = Path.GetFileNameWithoutExtension(request.File.FileName);
                document.FileLength = request.File.Length;
                document.FileExtension = Path.GetExtension(request.File.FileName);
                results.Add(document);
            }

            return results;
        }

        private async Task<Document> ExtractionMappingAsync(ExtractionRequest request)
        {
            if (work.UserRepository.NoTrackingEntities.FirstOrDefault(o => o.Id == request.UserId) == null)
            {
                throw new Exception("Không tìm thấy Id User");
            }
            
            var document = new HuceDocs.Data.Models.Document();

            document.UserId = request.UserId;
            
            document.DocumentTypeId = request.DocumentTypeId;

            document.FilePath = _fileManagerService.CreateRelativeFilePath(request.UserId, (int)eDocumentType.Extraction, (int)eFolder.input, Path.GetExtension(request.File.FileName));
            await _fileManagerService.CreateFile(document.FilePath, request.File);
            document.FileName = Path.GetFileNameWithoutExtension(request.File.FileName);
            document.FileLength = request.File.Length;
            document.FileExtension = Path.GetExtension(request.File.FileName);

            return document;
        }


        public ApiResult<DocumentVM> GetViewModelById(int id, int userid)
        {
            var data = work.DocumentRepository.Entities
                .Include(k => k.DocumentType)
                .Where(o => o.Id == id && o.UserId == userid);
            var result = data.Select(o => new DocumentVM
            {
                Id = o.Id,
                CreateDate = o.CreateDate,
                Description = o.Description,
                DocumentTypeId = o.DocumentTypeId,
                FileExtension = o.FileExtension,
                FileLength = o.FileLength,
                FileName = o.FileName,
                FilePath = o.FilePath,
                IsDelete = o.IsDelete,
                Status = o.Status,
                TotalOfFields = o.TotalOfFields,
                TotalOfPages = o.TotalOfPages,
                UserId = o.UserId,
            }).FirstOrDefault();
            if (result == null) return new ApiError<DocumentVM>("Không tìm thấy tài liệu");
            return new ApiSuccess<DocumentVM> { Result = result };
        }
        public async Task<ApiResult<bool>> CompletedAsync(int id, IFormFileCollection files, int pageCount, int? fieldCount, bool isOK, string description)
        {
            _logger.LogInformation("IdDoc=" + id + ": completed = " + isOK.ToString() + "_ at: " + DateTime.Now.ToString());
            var document = GetById(id).Result;
            double amount = 0;
            if (isOK)
            {
                // Save file
                try
                {
                    //var saved = false;
                    var saved2 = false;

                    string source = _config.GetValue<string>("FileManager:FileStorage") + "\\";

                    
                    //else // save file Extr
                    {

                        //saved = await ExtrSaveExcel(source, document, files);

                        saved2 = ExtrSaveFileOutput(source, document, files);

                    }

                    if (saved2)
                    {
                        work.DocumentRepository.Entities
                        .Where(o => o.Id == id)
                        .Update(o => new Data.Models.Document()
                        {
                            Status = (int)eDocumentStatus.Complete,
                            Description = null,
                            TotalOfPages = pageCount,
                            TotalOfFields = fieldCount ?? 0,
                        });
                        // send message to client
                        await _messageHub.SendUpdateDocumentStatus(document.UserId, document.Id, (int)eDocumentStatus.Complete);
                    }
                    // notify
                    var user = work.UserRepository.NoTrackingEntities.FirstOrDefault(o => o.Id == document.UserId);
                    var noti = _userService.GetUserById(user.Id);
                    //if (noti?.EmailNotification != false)
                    //{
                    //    var result = "Tài liệu <strong>" + document.FileName + "</strong> đã " + eGet.TypeOfDocument(document.Type) + " thành công.";
                    //    BackgroundJob.Enqueue(() => _emailService.SendEmailCompleted(user.Email, result));
                    //}
                    //if (noti?.AppNotification != false)
                    //{
                    //    await _notifyService.CreateAsync(new Data.Models.Notification
                    //    {
                    //        UserId = document.UserId,
                    //        FileName = document.FileName,
                    //        DocumentType = document?.DocumentType.Code,
                    //        CreateDate = DateTime.Now,
                    //        Status = (int)eNotifyStatus.success
                    //    });
                    //}
                    //// Cập nhập đã soát lỗi
                    //if (document.CheckType == (int)eDocumentCheckType.manual)
                    //{
                    //    work.VerifyRepository.Entities
                    //        .Where(o => o.DocumentId == id)
                    //        .Update(u => new Verify { Active = false });
                    //}
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Completed_IdDoc=" + document.Id + ":Lưu file kết quả không thành công:");
                }
                return new ApiError<bool>();
            }
            else
            {
                work.DocumentRepository.Entities
                    .Where(o => o.Id == id)
                    .Update(o => new Data.Models.Document()
                    {
                        Status = (int)eDocumentStatus.Failure,
                        Description = description
                    });
                // send message to client
                await _messageHub.SendUpdateDocumentStatus(document.UserId, document.Id, (int)eDocumentStatus.Failure);
                // send to notify
                await _notifyService.CreateAsync(new Data.Models.Notification
                {
                    UserId = document.UserId,
                    FileName = document.FileName,
                    DocumentType =  document?.DocumentType.Code,
                    CreateDate = DateTime.Now,
                    Status = (int)eNotifyStatus.failure
                });
            }
            return new ApiSuccess<bool>();
        }

        private bool ExtrSaveFileOutput(string source, Document document, IFormFileCollection files)
        {
            try
            {
                //string relativeFilePath = document.UserId + "\\" + document.Type + "\\" + "output";
                string relativeFilePath = document.UserId + "\\" + "" + "\\" + "output";
                if (!Directory.Exists(source + relativeFilePath))
                    Directory.CreateDirectory(source + relativeFilePath);
                var allJsonContent = new List<string>();
                int index = 1;
                foreach (var file in files)
                {
                    // read file FC Xml
                    dynamic xmlContent = new ExpandoObject();
                    var fileSteam = file.OpenReadStream();
                    var xmlDocument = XDocument.Load(fileSteam);
                    XmlHelper.FCXmlToDynamicObj(xmlContent, xmlDocument.Root);
                    var jsonContent = files.Count > 1 ? ("\"" + index + "\":" + JsonConvert.SerializeObject(xmlContent)) : JsonConvert.SerializeObject(xmlContent);
                    allJsonContent.Add(jsonContent);

                    index++;
                }

                var json = allJsonContent.Count > 1 ? ("{" + String.Join(',', allJsonContent) + "}") : allJsonContent.FirstOrDefault();
                //if (document.OutputExtensions != null && document.OutputExtensions.Count > 0)
                //{
                //    foreach (var outputextension in document.OutputExtensions.Select(k => k.OutputExtension?.Extension))
                //    {
                //        //if (string.Equals(outputextension, "xml", StringComparison.CurrentCulture))
                //        //{
                //        //    var fileName = Guid.NewGuid() + ".xml";
                //        //    var xmlContentOutput = JsonConvert.DeserializeXNode(json, "Document");

                //        //    XmlWriterSettings settings = new XmlWriterSettings();
                //        //    settings.OmitXmlDeclaration = true;
                //        //    using XmlWriter xw = XmlWriter.Create(Path.Combine(source, relativeFilePath + "\\" + fileName), settings);
                //        //    xmlContentOutput.Save(xw);

                //        //    work.OutputResultsRepository.Create(new OutputResults
                //        //    {
                //        //        FileName = document.FileName,
                //        //        FileExtension = ".xml",
                //        //        FilePath = relativeFilePath + "\\" + fileName,
                //        //        DocumentId = document.Id,
                //        //        CreateDate = DateTime.Now
                //        //    });
                //        //}
                //        //else
                //        //{
                //            var fileName = Guid.NewGuid() + ".json";

                //            File.WriteAllText(Path.Combine(source, relativeFilePath + "\\" + fileName), json);

                //            work.OutputResultsRepository.Create(new OutputResults
                //            {
                //                FileName = document.FileName,
                //                FileExtension = ".json",
                //                FilePath = relativeFilePath + "\\" + fileName,
                //                DocumentId = document.Id,
                //                CreateDate = DateTime.Now
                //            });
                //        //}
                //    }
                //}
                //else // k chọn định dạng đầu ra thì mặc định lưu .json
                {
                    var fileName = Guid.NewGuid() + ".json";
                    File.WriteAllText(Path.Combine(source, relativeFilePath + "\\" + fileName), json);

                    work.OutputResultsRepository.Create(new OutputResults
                    {
                        FileName = document.FileName,
                        FileExtension = ".json",
                        FilePath = relativeFilePath + "\\" + fileName,
                        DocumentId = document.Id,
                        CreateDate = DateTime.Now
                    });
                }

                return true;
            }
            catch { return false; }
        }

        private int ReadFilePdf(string filePath)
        {
            try
            {
                using (var file = new FileStream(filePath, FileMode.Open))
                {
                    using (var stream = new MemoryStream())
                    {
                        file.CopyTo(stream);
                        var pdf = new Aspose.Pdf.Document(stream);
                        return pdf.Pages.Count;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation("estimate: " + e.Message);
                return -1;
            }
        }

        private static bool IsFileReady(string filePath)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by another process.
            try
            {
                using (FileStream inputStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                    return inputStream.Length > 0;
            }
            catch (Exception)
            {
                System.Threading.Thread.Sleep(1000);
                return false;
            }
        }


        // Test


    }
}
