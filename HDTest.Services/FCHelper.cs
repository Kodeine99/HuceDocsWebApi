using HuceDocs.Services.ViewModels.OcrRequest;
using Microsoft.Data.SqlClient;
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
    public class FCHelper
    {
        private static string _connection = System.Configuration.ConfigurationManager.ConnectionStrings["OCRDatabase"].ConnectionString;
        private static string _serverUrl = System.Configuration.ConfigurationManager.AppSettings["FCserverUrl"];
        private static string _serverUri = System.Configuration.ConfigurationManager.AppSettings["FCServerUri"];
        //private static string username = Helper.RSADecryption(System.Configuration.ConfigurationManager.AppSettings["FCUsername"]);
        //private static string password = Helper.RSADecryption(System.Configuration.ConfigurationManager.AppSettings["FCPassword"]);

        private static string username = "ABCServer/administrator";
        private static string password = "Abc123456a@";

        private static string projectName = System.Configuration.ConfigurationManager.AppSettings["FCprojectName"];
        private static string groupUser = System.Configuration.ConfigurationManager.AppSettings["FCgroupUser"];
        private static string batchTypesName = "HuceDocs"; // ddefault batch

        private static string fileStorage = "E:\\WorkSpace\\HuceDocsOCR";

        public bool state = false;


        public FCHelper(ILogger<DocumentService> logger, HuceDocs.Data.Models.Document document)
        {
            
            string source = fileStorage + "\\" + document.FilePath;
            try
            {
                batchTypesName = document.DocumentType.FCCode;
                byte[] myBinary = System.IO.File.ReadAllBytes(source);
                UpdateToServer(myBinary);
            }
            catch (FileNotFoundException FileEx) 
            {
                logger.LogError("ExtrServiceError IdDoc=" + document.Id + ":" + FileEx.Message);Console.WriteLine(FileEx.Message);
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
        public static bool UpdateToServer(byte[] file, string type = null, string batchName = null)
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
                        
                        if (projectCurrent != null)
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
                        batch.Name = batchName;
                        batch.BatchTypeId = batchTypeId;

                        // register custom properties, use  for export to HuecDocs
                        //batch.Properties = new Batch.PropertiesType();

                        //batch.Properties.Add(new RegistrationProperty { Name = "Type", Value = type });
                        //batch.Properties.Add(new RegistrationProperty { Name = "SectionId", Value = sessionId.ToString() });


                    

                        // idUserOwner. -1 if allow all user to access
                        var idUser = -1; // service.FindUser(groupUser);
                        var batchId = service.AddNewBatch(sessionId, projectId, batch, idUser);
                        if (batchId <= 0)
                        {
                            //Logger.LogMessage("Couldn't create batch");
                            return false;
                        }

                        // add img (files) to batch
                        if (service.OpenBatch(sessionId, batchId))
                        {
                            service.AddNewImage(sessionId, batchId, new File()
                            {
                                Bytes = file,
                                Name = batch.Name
                            });
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
        public static bool DeleteBatch(int batchId)
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
        public static bool SendToStage(int batchId, string stageName, out string message)
        {
            try
            {
                var service = GetServiceInstance();
                var sessionId = service.OpenSession(12, 10);

                var projectId = GetProject(service)?.Id;
                if (projectId <= 0)
                {
                    message = "Couldn't find project";
                    return false;
                }
                var batch = service.GetBatch(batchId);

                var stages = service.GetProcessingStages((Int32)projectId, batch.BatchTypeId, StageType.Script, stageName);

                var taskId = GetTaskId(batchId, (Int32)projectId);
                if (taskId > 0)
                {
                    service.SendTask(sessionId, taskId, stages.FirstOrDefault().Id, null);
                    service.CloseSession(sessionId);
                    message = "SUCCESS";
                    return true;
                }
                else
                {
                    service.CloseSession(sessionId);
                    message = batch.Name + "send to stage failed";
                    //Logger.LogError(message);
                    return false;
                }
            }
            catch (Exception e)
            {
                //Logger.LogError("Cannot access to FC service soap");
                //Logger.LogError(e.ToString());
                message = "FAIL";
                return false;
            }
        }

        /// <summary>
        /// return current stage of batch
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns>return current stage of batch</returns>
        public static Stage GetBatchStage(int batchId)
        {
            try
            {
                var service = GetServiceInstance();
                var projectId = (Int32)GetProject(service)?.Id;
                var stage = GetStage(batchId, projectId);
                return stage;
            }
            catch (Exception e)
            {
                //Logger.LogError("Cannot get stage batch id = " + batchId);
                //Logger.LogError(e.ToString());
                return null;
            }
        }

        /// <summary>
        /// Return current project information
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Return current project information</returns>
        public static Project GetProject(FlexiCaptureWebServiceSoapClient service)
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
        public static WindowsFormsApplication1.fc12.BatchType GetBatchType(FlexiCaptureWebServiceSoapClient service, int projectId, string batchTypeName)
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
        public static int GetTaskId(int batchId, int projectId)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"Select Id From dbo.Task Where BatchId = {batchId} AND Project = {projectId}", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }

                reader.Dispose();
                cmd.Dispose();
                connection.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchId"></param>
        /// <param name="projectId"></param>
        /// <returns>Return current stage by batchId and projectId</returns>
        public static Stage GetStage(int batchId, int projectId)
        {
            var stage = new Stage();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"Select dbo.ProcessingStage.Id, dbo.ProcessingStage.Name," +
                    $" dbo.ProcessingStage.Type FROM task JOIN dbo.ProcessingStage on dbo.Task.CurrentProcessingStageId" +
                    $" = dbo.ProcessingStage.Id where dbo.Task.BatchId = {batchId} and task.projectid = {projectId}", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stage.Id = reader.GetInt32(0);
                    stage.Name = reader.GetString(1);
                    stage.Type = reader.GetInt32(2);
                }
                reader.Dispose();
                cmd.Dispose();
                connection.Dispose();
            }

            return stage;
        }

        public static string GetBatchTypeName(string ecmType)
        {
            switch (ecmType)
            {
                case EcmType.TheSinhVien: return BatchType.HuceDocs;
                case EcmType.GiayCamKetTraNo: return BatchType.HuceDocs;
                case EcmType.BangDiemTiengAnh: return BatchType.HuceDocs;

                default:
                    return "HuceDocs";
            }
        }

        public static FlexiCaptureWebServiceSoapClient GetServiceInstance()
        {
            try
            {
                var serverUri = _serverUrl + _serverUri;

                var binding = new BasicHttpBinding();
                binding.Security.Mode = BasicHttpSecurityMode.Transport;

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

        public File LoadFile(string fileName)
        {
            var file = new File();
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
