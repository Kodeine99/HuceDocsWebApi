using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using WindowsFormsApplication1.fc12;
using HuceDocs.Services.ViewModels.Document;
using HuceDocs.Services;
using File = WindowsFormsApplication1.fc12.File;

namespace HuceDocs.Services.Service_References
{
    public class ExtrServices
    {
        private readonly string _serverUrl;
        private readonly string _serverUri;
        private readonly string userName;
        private readonly string passWord;
        private readonly string projectName;
        private string groupUser;
        private string batchTypesName = "HuceDocs";
        private readonly ExtrConfigModel _config;
        private readonly ILogger<DocumentService> _logger;

        public bool state = false;
        private static Random random = new Random();
        public ExtrServices(ExtrConfigModel config, ILogger<DocumentService> logger, HuceDocs.Data.Models.Document document)
        {
            _config = config;
            _logger = logger;
            _serverUrl = _config.ServerUrl;
            _serverUri = _config.ServerUri;
            userName = _config.UserName;
            passWord = _config.PassWord;
            projectName = _config.ProjectName;
            groupUser = _config.GroupUser;
            string source = _config.FileStorage + "\\" + document.FilePath;
            try
            {
                batchTypesName = document.DocumentType.FCCode;
                byte[] myBinary = System.IO.File.ReadAllBytes(source);
                RunDataFileByte(myBinary, document.Id.ToString());
            }
            catch (FileNotFoundException ioEx)
            {
                _logger.LogError("ExtrServiceError IdDoc=" + document.Id + ":" + ioEx.Message);
                Console.WriteLine(ioEx.Message);
            }
        }
        private void RunDataCapture(string pathToFile, string idDoc)
        {
            try
            {
                // Initialize service 
                var serverUri = _serverUrl + this._serverUri;

                var binding = new BasicHttpBinding();

                // The size of a default message is too small for FlexiCapture and must me increased
                binding.MaxReceivedMessageSize = 4 * 1024 * 1024;
                binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;

                // Selecting an authentiction method
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

                var remoteAddress = new EndpointAddress(new Uri(serverUri));

                // Creating a SOAP client
                var service = new FlexiCaptureWebServiceSoapClient(binding, remoteAddress);

                service.ClientCredentials.UserName.UserName = userName;
                service.ClientCredentials.UserName.Password = passWord;


                var sessionId = service.OpenSession(12, 10);
                try
                {
                    var projects = service.GetProjects();

                    var projectGuid = string.Empty;
                    if (projects != null)
                    {
                        foreach (var project in service.GetProjects())
                        {
                            if (project.Name != projectName)
                                continue;
                            projectGuid = project.Guid;
                        }

                        var projectId = service.OpenProject(sessionId, projectGuid); //vì chỉ có 1 project FC_DARS
                        projectId = (projectId == 0) ? 1 : projectId;
                        // List available batch types 
                        //var b = service.GetBatchType(0);
                        var batchTypes = service.GetBatchTypes(projectId);
                        var batchTypeId = 0;
                        if (batchTypes != null)
                        {
                            foreach (var batchType in batchTypes)
                            {
                                if (batchType.Name != batchTypesName)
                                    continue;
                                batchTypeId = batchType.Id;
                            }
                        }

                        var batch = new Batch();
                        batch.Name = idDoc;
                        batch.BatchTypeId = batchTypeId; //ID của VBPQ;
                        var idUser = service.FindUser(userName);
                        var batchId = service.AddNewBatch(sessionId, projectId, batch, idUser);
                        Console.WriteLine(batchId);
                        // Load sample images (see below for definition of LoadFile) 
                        if (service.OpenBatch(sessionId, batchId))
                        {
                            var file1 = LoadFile(pathToFile);
                            //var file1 = FileByte(bytesFile);

                            service.AddNewImage(sessionId, batchId, file1);

                            service.CloseBatch(sessionId, batchId);

                            service.ProcessBatch(sessionId, batchId);
                        }
                        service.CloseProject(sessionId, projectId);
                    }
                }
                finally
                {
                    service.CloseSession(sessionId);
                    this.state = true;
                }
            }
            catch (Exception ex)
            // Use catch ( SoapException ex ) to catch only exceptions which are raised by 
            // Application Server 
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RunDataFileByte(byte[] bytesFile, string idDoc)
        {
            try
            {
                // Initialize service 
                var serverUri = _serverUrl + this._serverUri;

                var binding = new BasicHttpBinding();

                // The size of a default message is too small for FlexiCapture and must me increased
                binding.MaxReceivedMessageSize = 4 * 1024 * 1024;
                binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;

                // Selecting an authentiction method
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

                var remoteAddress = new EndpointAddress(new Uri(serverUri));

                // Creating a SOAP client
                var service = new FlexiCaptureWebServiceSoapClient(binding, remoteAddress);

                service.ClientCredentials.UserName.UserName = userName;
                service.ClientCredentials.UserName.Password = passWord;


                var sessionId = service.OpenSession(12, 10);
                try
                {
                    var projects = service.GetProjects();
                    if (projects != null)
                    {
                        var projectCurrent = projects.FirstOrDefault(k =>
                            k.Name.Contains(this.projectName, StringComparison.CurrentCulture));
                        if (projectCurrent == null)
                        {
                            _logger.LogError($"Không tìm thấy projectName: {projectName} ({serverUri})");
                            service.CloseSession(sessionId);
                            this.state = false;
                            return;
                        }

                        var projectId = service.OpenProject(sessionId, projectCurrent.Name); //vì chỉ có 1 project FC_DARS
                        _logger.LogTrace($"projectName: {projectName} ; projectId:{projectId}; projectGuid:{projectCurrent.Guid}");
                        projectId = projectCurrent.Id;
                        // List available batch types 
                        //var b = service.GetBatchType(0);
                        var batchTypes = service.GetBatchTypes(projectId);
                        var batchTypeId = 0;
                        if (batchTypes != null)
                        {
                            foreach (var batchType in batchTypes)
                            {
                                if (batchType.Name != batchTypesName)
                                    continue;
                                batchTypeId = batchType.Id;
                            }
                        }

                        var batch = new Batch();
                        batch.Name = idDoc;
                        batch.BatchTypeId = batchTypeId; //ID của VBPQ;
                        var idUser = service.FindUser(groupUser);
                        var batchId = service.AddNewBatch(sessionId, projectId, batch, idUser);
                        Console.WriteLine(batchId);
                        // Load sample images (see below for definition of LoadFile) 
                        if (service.OpenBatch(sessionId, batchId))
                        {
                            var file1 = FileByte(bytesFile);
                            //var file1 = FileByte(bytesFile);

                            service.AddNewImage(sessionId, batchId, file1);

                            service.CloseBatch(sessionId, batchId);

                            service.ProcessBatch(sessionId, batchId);
                        }

                        service.CloseProject(sessionId, projectId);
                        this.state = true;
                        _logger.LogInformation("ExtrServices_IdDoc=" + idDoc + ": Đã chuyển sang FC; batchId=" + batchId);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("ExtrServiceError IdDoc=" + idDoc + ":" + ex.Message);
                }
                finally
                {
                    service.CloseSession(sessionId);
                }
            }
            catch (Exception ex)
            // Use catch ( SoapException ex ) to catch only exceptions which are raised by 
            // Application Server 
            {
                this.state = false;
                _logger.LogError("ExtrServiceError IdDoc=" + idDoc + ":" + ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
        public File LoadFile(string fileName)
        {
            var file = new File();

            using (var stream = System.IO.File.Open(fileName, FileMode.Open))
            {
                file.Name = fileName;

                file.Bytes = new byte[stream.Length];

                stream.Read(file.Bytes, 0, file.Bytes.Length);
            }

            return file;
        }
        public File FileByte(byte[] bytesFile)
        {
            var file = new File();

            file.Name = DateTime.Now + "_" + RandomString(7);

            file.Bytes = bytesFile;

            return file;
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
