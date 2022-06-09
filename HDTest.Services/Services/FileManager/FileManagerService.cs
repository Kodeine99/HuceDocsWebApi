using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using HuceDocs.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HuceDocs.Services
{
    public class FileManagerService : IFileManagerService
    {
        
        private readonly ILogger<FileManagerService> _logger;
        private readonly IConfiguration _config;
        private readonly IFileManagerIO fileManagerIo;

        #region property
        // root folder chứa file
        private readonly string localRootFolder;
        // root folder chứa file tạm
        private string localTempFolder => Path.Combine(localRootFolder, "Temp");
        // root folder chứa file app
        public string AppFolder { get; }
        // root folder chứa file log
        public string LogFolder { get; }
        // root folder chứa file template report
        public string TemplateFolder { get; }
        #endregion

        public FileManagerService(ILogger<FileManagerService> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            var isInternetApp = _config.GetValue<string>("FileManager:IsInternetApp") == "true";
            if (isInternetApp)
                fileManagerIo = new FileManagerIOFTPClient(_config.GetValue<string>("FileManager:FileStorageFTP"));
            else
                fileManagerIo = new FileManagerIOFileSystem(_config.GetValue<string>("FileManager:FileStorage"));

            localRootFolder = _config.GetValue<string>("FileManager:FileStorage");
            if (Directory.Exists(this.localRootFolder) == false)
                Directory.CreateDirectory(this.localRootFolder);
            if (Directory.Exists(localTempFolder) == false)
                Directory.CreateDirectory(localTempFolder);

            // config folder file app
            var appPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase.Replace(@"file:///", "")));
            AppFolder = Path.Combine(appPath, "app_data");
            LogFolder = Path.Combine(appPath, "app_data", "logs" + Path.DirectorySeparatorChar);
            TemplateFolder = Path.Combine(appPath, "app_data", "template" + Path.DirectorySeparatorChar);
        }
        

        // tạo địa chỉ tương đối
        public string CreateRelativeFilePath(int userId, int typeId, int inOutPut, string extension)
        {
            return fileManagerIo.GetFilePath(userId, typeId, inOutPut, extension);
        }
        // kiểm tra file từ địa chỉ tương đối
        public bool CheckIfFileExist(string relativeFilePath)
        {
            return fileManagerIo.FileExists(relativeFilePath);
        }
        // tạo địa chỉ tuyệt đối
        public string CreateFullLocalPath(int userId, int typeId, int inOutPut, string extension)
        {
            var relativeFilePath = fileManagerIo.GetFilePath(userId, typeId, inOutPut, extension);
            return fileManagerIo.GetFullFilePath(relativeFilePath);
        }

        /// <summary> Tạo đường dẫn file tạm để lưu dữ liệu tạm thời </summary>
        public string CreateNewTempPath(string extension)
        {
            return Path.Combine(localTempFolder, $"{Guid.NewGuid()}.{extension}");
        }

        // lấy file stream từ địa chỉ tương đối
        public Stream GetFileData(string relativeFilePath)
        {
            var filePath = fileManagerIo.GetFullFilePath(relativeFilePath);
            return fileManagerIo.GetFileData(filePath);
        }
        // lấy file path từ địa chỉ tương đối
        public string GetFullFilePath(string relativeFilePath)
        {
            return fileManagerIo.GetFullFilePath(relativeFilePath);
        }
        // delete file từ địa chỉ tương đối
        public void DeleteFile(string relativeFilePath)
        {
            fileManagerIo.FileDelete(relativeFilePath);
        }
        // tạo file từ thông tin document
        public async Task CreateFile(int userId, int typeId, int inOutPut, string extension, IFormFile file)
        {
            var relativeFilePath = fileManagerIo.GetFilePath(userId, typeId, inOutPut, extension);
            var newPath = fileManagerIo.GetFullFilePath(relativeFilePath);
            var directoryPath = fileManagerIo.GetDirectoryPath(newPath);
            if (fileManagerIo.DirectoryExists(directoryPath) == false)
                fileManagerIo.DirectoryCreate(directoryPath);
            if (fileManagerIo.FileExists(newPath))
                fileManagerIo.FileDelete(newPath);
            await using var stream = new FileStream(newPath, FileMode.Create);
            await file.CopyToAsync(stream);
        }

        // tạo file từ địa chỉ tương đối
        public async Task CreateFile(string relativeFilePath, IFormFile file)
        {
            var newPath = fileManagerIo.GetFullFilePath(relativeFilePath);
            var directoryPath = fileManagerIo.GetDirectoryPath(newPath);
            if (fileManagerIo.DirectoryExists(directoryPath) == false)
                fileManagerIo.DirectoryCreate(directoryPath);
            if (fileManagerIo.FileExists(newPath))
                fileManagerIo.FileDelete(newPath);
            await using var stream = new FileStream(newPath, FileMode.Create);
            await file.CopyToAsync(stream);
        }
    }
}
