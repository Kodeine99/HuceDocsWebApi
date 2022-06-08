using HuceDocs.Data.Models;
using HuceDocs.Data.Repository;
using HuceDocs.Notification.Client;
using HuceDocs.Services.EnumDefine;
using HuceDocs.Services.ModelFilter;
using HuceDocs.Services.Service_References;
using HuceDocs.Services.Services;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.Category;
using HuceDocs.Services.ViewModels.Common;
using HuceDocs.Services.ViewModels.Document;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        // Rework
        public async Task<ApiResult<bool>> ReworkAsync(int id, int userId)
        {
            try
            {
                var document = GetById(id, userId).Result;
                if (
                    document.Status != (int)eDocumentStatus.ErrorRead &&
                    document.Status != (int)eDocumentStatus.Failure 
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
                    var saved = false;
                    var saved2 = false;

                    string source = _config.GetValue<string>("FileManager:FileStorage") + "\\";

                    
                    else // save file Extr
                    {
                        
                            saved = await ExtrSaveExcel(source, document, files);
                        
                            saved2 = ExtrSaveFileOutput(source, document, files);
                        
                    }

                    if (saved)
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
                    if (noti?.EmailNotification != false)
                    {
                        var result = "Tài liệu <strong>" + document.FileName + "</strong> đã " + eGet.TypeOfDocument(document.Type) + " thành công.";
                        BackgroundJob.Enqueue(() => _emailService.SendEmailCompleted(user.Email, result));
                    }
                    if (noti?.AppNotification != false)
                    {
                        await _notifyService.CreateAsync(new Data.Models.Notification
                        {
                            UserId = document.UserId,
                            FileName = document.FileName,
                            DocumentType = document.Type == (int)eDocumentType.Digitization ? "recognize" : document?.DocumentType.Code,
                            CreateDate = DateTime.Now,
                            Type = document.Type,
                            Status = (int)eNotifyStatus.success
                        });
                    }
                    // Cập nhập đã soát lỗi
                    if (document.CheckType == (int)eDocumentCheckType.manual)
                    {
                        work.VerifyRepository.Entities
                            .Where(o => o.DocumentId == id)
                            .Update(u => new Verify { Active = false });
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Completed_IdDoc=" + document.Id + ":Lưu file kết quả không thành công:");
                }
                return new ApiErrorResult<bool>();
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
                    DocumentType = document.Type == (int)eDocumentType.Digitization ? "recognize" : document?.DocumentType.Code,
                    CreateDate = DateTime.Now,
                    Type = document.Type,
                    Status = (int)eNotifyStatus.failure
                });
            }
            return new ApiSuccessResult<bool>();
        }



    }
}
