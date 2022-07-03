using HuceDocs.Services.ViewModels;
using HuceDocs.Services.ViewModels.Document;
using HuceDocs.Services.ViewModels.OcrRequest;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using WindowsFormsApplication1.fc12;

namespace HuceDocs.Services
{
    public  class FCHelper
    {
        //private string _connection = System.Configuration.ConfigurationManager.ConnectionStrings["OCRDatabase"].ConnectionString;
        //private string _serverUrl = System.Configuration.ConfigurationManager.AppSettings["ExtrServer:FCServerUrl"];
        //private string _serverUri = System.Configuration.ConfigurationManager.AppSettings["ExtrServer:FCServerUri"];
        //private string username = System.Configuration.ConfigurationManager.AppSettings["ExtrServer:FCUsername"];
        //private string password = System.Configuration.ConfigurationManager.AppSettings["ExtrServer:FCPassword"];


        private string username = "tungnv";
        private string password = "tung123456a@";
        private string _serverUri = "/FlexiCapture12/Server/FCAuth/API/v1/Soap";
        private string _serverUrl = "http://10.10.10.99";
        private string projectName = "HuceDocs";
        //private string groupUser = "abc123456a@";

        //private  string projectName = System.Configuration.ConfigurationManager.AppSettings["FCProjectName"];
        //private  string groupUser = System.Configuration.ConfigurationManager.AppSettings["FCGroupUser"];
        private string batchTypesName = "HuceDocs"; // ddefault batch

       // private  string fileStorage = "E:\\WorkSpace\\HuceDocsOCR";

        //private readonly string _serverUrl;
        //private readonly string _serverUri;
        //private readonly string username;
        //private readonly string password;
        //private readonly string projectName;
        //private string groupUser;
        //private string batchTypesName = "HuceDocs";
        //private readonly ExtrConfigModel _config;
        //private readonly ILogger<DocumentServices> _logger;

        public bool state = false;

       
        public FCHelper(ILogger<DocumentService> logger, List<HFileVM> hFiles, int documentId, string ExtractType, int userId)
        {
            //_config = config;
            //_logger = logger;
            //_serverUrl = _config.ServerUrl;
            //_serverUri = _config.ServerUri;
            //username = _config.Username;
            //password = _config.Password;
            //projectName = _config.ProjectName;
            //groupUser = _config.GroupUser;
            //st<string> filePaths = 
            //string source = fileStorage + "\\" + document.FilePath;

            List<byte[]> files = new List<byte[]>();
            foreach (HFileVM hFile in hFiles)
            {
                files.Add(System.IO.File.ReadAllBytes(hFile.FilePath));
            }

            
            try
            {
                //batchTypesName = ExtractType;

                //byte[] myBinary = System.IO.File.ReadAllBytes(hFileVM.FilePath);
                UpdateToServer(files, ExtractType, documentId.ToString(), userId);
            }
            catch (FileNotFoundException FileEx)
            {
                logger.LogError("ExtrServiceError IdDoc=" + documentId+ ":" + FileEx.Message); Console.WriteLine(FileEx.Message);
                throw;
            }
            
   
        }


        /// <summary>
        /// Create job on OCR request information
        /// </summary>
        /// <param name="file"></param>
        /// <param name="type"></param>
        /// <param name="batchName"></param>
        /// <returns></returns>
        public  bool UpdateToServer(List<byte[]> files, string type , string documentId, int userId)
        {
            //Logger.LogMessage("Start upload file to OCR");
            batchTypesName = GetBatchTypeName(type);
            try
            {
                // get an instance of service 
                var service = GetServiceInstance();

                // create session
                var sessionId = service.OpenSession(12, 10);
                //Logger.LogMessage("SesssionId = " + sessionId + " is opening");
                try
                {
                    var projects = service.GetProjects();
                    if (projects != null)
                    {
                        // get project id
                        var projectCurrent = projects.FirstOrDefault(k => k.Name.Contains(projectName));
                        
                        if (projectCurrent == null)
                        {
                            //Logger.LogMessage("Not found" + projectName + "project");
                            service.CloseSession(sessionId);
                            return false;
                        }
                        var projectId = service.OpenProject(sessionId, projectCurrent.Name);
                        projectId = projectCurrent.Id;
                        //Logger.LogMessage("ProjectId = " + projectId);

                        // get batchType id
                        var batchTypes = service.GetBatchTypes(projectId);
                        var batchTypeId = 0;
                        if (batchTypes != null)
                        {
                            foreach (var batchType in batchTypes)
                            {
                                if (batchType.Name != batchTypesName)
                                {
                                    continue;
                                }
                                batchTypeId = batchType.Id;
                            }
                        }
                        //Logger.LogMessage("BatchTypeId = " + batchTypeId);

                        // create batch
                        var batch = new Batch();
                        batch.Name = batchTypesName +"_"+ documentId;
                        batch.BatchTypeId = batchTypeId;

                        // register custom properties, use  for export to HuceDocs

                        batch.Properties = new Batch.PropertiesType();

                        batch.Properties.Add(new RegistrationProperty { Name = "Type", Value = type });
                        batch.Properties.Add(new RegistrationProperty { Name = "HDUserId", Value = userId.ToString()});
                        batch.Properties.Add(new RegistrationProperty { Name = "HDDocumentId", Value = documentId});


                    

                        // idUserOwner. -1 if allow all user to access
                        var idUser = -1; // service.FindUser(groupUser);
                        var batchId = service.AddNewBatch(sessionId, projectId, batch, idUser);
                        //if (batchId <= 0)
                        //{
                        //    //Logger.LogMessage("Couldn't create batch");
                        //    return false;
                        //}

                        // add img (files) to batch
                        if (service.OpenBatch(sessionId, batchId))
                        {
                            foreach (var file in files)
                            {
                                service.AddNewImage(sessionId, batchId, new WindowsFormsApplication1.fc12.File()
                                {
                                    Bytes = file,
                                    Name = batch.Name
                                });
                            }
                            service.CloseBatch(sessionId, batchId);
                            //execute batch
                            service.ProcessBatch(sessionId, batchId);
                        }

                        service.CloseProject(sessionId, projectId);
                        //Logger.LogMessage("Send to FC Successed: batchId: " + batchId + "_batch.Name: " + batch.Name);
                    }
                    else
                    {
                        //Logger.LogMessage("Project nopt found");
                        return false;
                    }
                }
                catch (Exception e)
                {
                    //Logger.LogMessage("Fail to create batch");
                    //Logger.LogError(e.ToString());
                }
                finally
                {
                    service.CloseSession(sessionId);
                    state = true;
                }
                return true;
            }
            catch (Exception e)
            {
                //Logger.LogMessage("Fail to connect to OCR");
                //Logger.LogError(e.ToString());
                return false;
                throw;
            }
        }

        /// <summary>
        /// Delete Batch with batch id
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        public  bool DeleteBatch(int batchId)
        {
            try
            {
                var service = GetServiceInstance();
                var sessionId = service.OpenSession(12, 10);
                var result = service.DeleteBatch(sessionId, batchId);
                service.CloseSession(sessionId);

                return result;
            }
            catch (Exception e)
            {
                //Logger.LogError("Cannoit delete batch id: " + batchId);
                //Logger.LogError(e.ToString());
                return false;
                throw;
            }
        }

        /// <summary>
        /// Change Stage of batch (re-recognize, re-export)
        /// </summary>
        /// <param name="batchId"></param>
        /// <param name="stageName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        //public  bool SendToStage(int batchId, string stageName, out string message)
        //{
        //    try
        //    {
        //        var service = GetServiceInstance();
        //        var sessionId = service.OpenSession(12, 10);

        //        var projectId = GetProject(service)?.Id;
        //        if (projectId <= 0)
        //        {
        //            message = "Couldn't find project";
        //            return false;
        //        }
        //        var batch = service.GetBatch(batchId);

        //        var stages = service.GetProcessingStages((Int32)projectId, batch.BatchTypeId, StageType.Script, stageName);

        //        var taskId = GetTaskId(batchId, (Int32)projectId);
        //        if (taskId > 0)
        //        {
        //            service.SendTask(sessionId, taskId, stages.FirstOrDefault().Id, null);
        //            service.CloseSession(sessionId);
        //            message = "SUCCESS";
        //            return true;
        //        }
        //        else
        //        {
        //            service.CloseSession(sessionId);
        //            message = batch.Name + "send to stage failed";
        //            //Logger.LogError(message);
        //            return false;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        //Logger.LogError("Cannot access to FC service soap");
        //        //Logger.LogError(e.ToString());
        //        message = "FAIL";
        //        return false;
        //    }
        //}

        /// <summary>
        /// return current stage of batch
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns>return current stage of batch</returns>
        //public  Stage GetBatchStage(int batchId)
        //{
        //    try
        //    {
        //        var service = GetServiceInstance();
        //        var projectId = (Int32)GetProject(service)?.Id;
        //        var stage = GetStage(batchId, projectId);
        //        return stage;
        //    }
        //    catch (Exception e)
        //    {
        //        //Logger.LogError("Cannot get stage batch id = " + batchId);
        //        //Logger.LogError(e.ToString());
        //        return null;
        //    }
        //}

        /// <summary>
        /// Return current project information
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Return current project information</returns>
        public  Project GetProject(FlexiCaptureWebServiceSoapClient service)
        {
            var projects = service.GetProjects();
            if (projects == null || projects?.Count <= 0)
            {
                return null;
            }
            var projectCurrent = projects.FirstOrDefault(k => k.Name.Contains(projectName));
            
            if (projectCurrent == null)
            {
                return null;
            }
            return projectCurrent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sevice"></param>
        /// <param name="projectId"></param>
        /// <param name="batchTypeName"></param>
        /// <returns>Return batchtype information by ProjectId and name of batch type</returns>
        public  WindowsFormsApplication1.fc12.BatchType GetBatchType(FlexiCaptureWebServiceSoapClient service, int projectId, string batchTypeName)
        {
            var batchTypes = service.GetBatchTypes(projectId);
            if (batchTypes == null || batchTypes?.Count < 0)
            {
                return null;
            }
            var batchTypeCurrent = batchTypes.FirstOrDefault(k => k.Name.Contains(batchTypeName));
            if (batchTypeCurrent == null)
            {
                return null;
            }
            return batchTypeCurrent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchId"></param>
        /// <param name="projectId"></param>
        /// <returns>Return current TaskId by batchId and projectId</returns>
        //public  int GetTaskId(int batchId, int projectId)
        //{
        //    int result = 0;
        //    using (SqlConnection connection = new SqlConnection(_connection))
        //    {
        //        connection.Open();
        //        SqlCommand cmd = new SqlCommand($"Select Id From dbo.Task Where BatchId = {batchId} AND Project = {projectId}", connection);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            result = reader.GetInt32(0);
        //        }

        //        reader.Dispose();
        //        cmd.Dispose();
        //        connection.Dispose();
        //    }
        //    return result;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchId"></param>
        /// <param name="projectId"></param>
        /// <returns>Return current stage by batchId and projectId</returns>
        //public  Stage GetStage(int batchId, int projectId)
        //{
        //    var stage = new Stage();

        //    using (SqlConnection connection = new SqlConnection(_connection))
        //    {
        //        connection.Open();
        //        SqlCommand cmd = new SqlCommand($"Select dbo.ProcessingStage.Id, dbo.ProcessingStage.Name," +
        //            $" dbo.ProcessingStage.Type FROM task JOIN dbo.ProcessingStage on dbo.Task.CurrentProcessingStageId" +
        //            $" = dbo.ProcessingStage.Id where dbo.Task.BatchId = {batchId} and task.projectid = {projectId}", connection);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            stage.Id = reader.GetInt32(0);
        //            stage.Name = reader.GetString(1);
        //            stage.Type = reader.GetInt32(2);
        //        }
        //        reader.Dispose();
        //        cmd.Dispose();
        //        connection.Dispose();
        //    }

        //    return stage;
        //}

        public  string GetBatchTypeName(string ecmType)
        {
            switch (ecmType)
            {
                case EcmType.TheSinhVien: return BatchType.TheSinhVien;
                case EcmType.CCCD: return BatchType.CCCD;
                case EcmType.GiayCamKetTraNo: return BatchType.GiayCamKetTraNo;
                case EcmType.BangDiemTiengAnh: return BatchType.BangDiemTiengAnh;
                case EcmType.GiayXacNhanToeic: return BatchType.GiayXacNhanToeic;
                case EcmType.BangDiem: return BatchType.BangDiem;
                case EcmType.GiayXacNhanVayVon: return BatchType.GiayXacNhanVayVon;
                case EcmType.DonXinNhapHoc: return BatchType.DonXinNhapHoc;

                default:
                    return "HuceDocs";
            }
        }

        public  FlexiCaptureWebServiceSoapClient GetServiceInstance()
        {
            try
            {
                var serverUri = _serverUrl + this._serverUri;

                var binding = new BasicHttpBinding();
                binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;

                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

                var remoteAddess = new EndpointAddress(new Uri(serverUri));

                var service = new FlexiCaptureWebServiceSoapClient(binding, remoteAddess);
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                service.ClientCredentials.UserName.UserName = username;
                service.ClientCredentials.UserName.Password = password;

                return service;
            }
            catch (Exception e)
            {
                //Logger.LogError("Cannot access to FC Service Soap");
                //Logger.LogError(e.ToString());
                throw;
            }
        }

        public class HttpAuthHeaderMessageInspector : IClientMessageInspector
        {
            public HttpAuthHeaderMessageInspector(string authTicket)
            {
                AuthTicket = authTicket;
            }
            public string AuthTicket { get; private set; }

            private const string authTicketName = "AuthTicket";
            private const string authorizationHeader = "Authorization";
            private const string bearerPrefix = "Bearer";

            #region IClientMessageInspector Members

            public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
            {
                if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out object httpRequestMessageObject))
                {
                    HttpRequestMessageProperty httpRequestMessage = httpRequestMessageObject as HttpRequestMessageProperty;
                    httpRequestMessage.Headers[authorizationHeader] = bearerPrefix + AuthTicket;
                }
                else
                {
                    HttpRequestMessageProperty httpRequestMessage = new HttpRequestMessageProperty();
                    httpRequestMessage.Headers.Add(authorizationHeader, bearerPrefix + AuthTicket);
                    request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
                }
                return null;
            }

            /// <summary>
            /// Refresh current authentication ticket value from response message header
            /// </summary>
            /// <param name="reply"></param>
            /// <param name="correlationState"></param>
            public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
            {
                if (reply.Properties.TryGetValue(HttpResponseMessageProperty.Name, out object httpResponseMessageObject))
                {
                    HttpResponseMessageProperty httpResponseMessage = httpResponseMessageObject as HttpResponseMessageProperty;
                    if (!string.IsNullOrEmpty(httpResponseMessage.Headers[authTicketName]))
                    {
                        AuthTicket = httpResponseMessage.Headers[authTicketName];
                    }
                }
            }
            #endregion
        }

        public class HttpAuthHeaderEnpointBehavior : IEndpointBehavior
        {
            public HttpAuthHeaderEnpointBehavior(string authTicket)
            {
                AuthTicket = authTicket;
            }
            public string AuthTicket { get; private set; }

            #region IEnpointBehavior Members

            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {

            }

            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
                clientRuntime.ClientMessageInspectors.Add(new HttpAuthHeaderMessageInspector(AuthTicket));
            }

            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
            {

            }

            public void Validate(ServiceEndpoint endpoint)
            {

            }
            #endregion
        }

        public WindowsFormsApplication1.fc12.File LoadFile(string fileName)
        {
            var file = new WindowsFormsApplication1.fc12.File();
            using (var stream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
            {
                file.Name = fileName;

                file.Bytes = new byte[stream.Length];
            }
            return file;
        }
        public class Stage
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Type { get; set; }
        }
    }



}
