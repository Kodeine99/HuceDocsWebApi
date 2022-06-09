using System;
using System.IO;
using System.Net;
using FluentFTP;
using Flurl;

namespace HuceDocs.Services
{
    public class FileManagerIOFTPClient : IFileManagerIO
    {
        private string rootPath;
        public char DirectorySeparatorChar => '/';

        public FileManagerIOFTPClient(string rootPath)
        {
            this.rootPath = rootPath;
        }

        public bool FileExists(string filePath)
        {
            using (var ftpClient = CreateFtpClient())
            {
                return ftpClient.FileExists(filePath);
            }
        }

        public void FileDelete(string filePath)
        {
            using (var ftpClient = CreateFtpClient())
            {
                ftpClient.DeleteFile(filePath);
            }
        }

        public bool DirectoryExists(string dirPath)
        {
            using (var ftpClient = CreateFtpClient())
            {
                return ftpClient.DirectoryExists(dirPath);
            }
        }

        public void DirectoryDelete(string dirPath)
        {
            using (var ftpClient = CreateFtpClient())
            {
                ftpClient.DeleteDirectory(dirPath);
            }
        }

        public void DirectoryCreate(string dirPath)
        {
            using (var ftpClient = CreateFtpClient())
            {
                ftpClient.CreateDirectory(dirPath);
            }
        }
        
        public string GetDirectoryPath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException($"{nameof(filePath)} phải có giá trị");
            return filePath.Substring(0, filePath.LastIndexOf(this.DirectorySeparatorChar));
        }

        public string PathCombine(string path1, string path2)
        {
            return Url.Combine(path1, path2);
        }

        public string PathCombine(string path1, string path2, string path3)
        {
            return Url.Combine(path1, path2, path3);
        }
        public string GetFullFilePath(string relativePath)
        {
            return Path.Combine(rootPath, relativePath);
        }
        public string GetFilePath(int userId, int typeId, int inOutPut, string extension)
        {
            var filePath = Path.Combine(Convert.ToString(userId), Convert.ToString(typeId), (inOutPut == 0 ? "input" : "output"), $"{Guid.NewGuid()}.{extension}");
            return filePath.Replace("\\", "/"); ;
        }
        public string GetFileServerAnalysisPath(int typeId, int? docTypeId, int inOutPut, string extension)
        {
            string filePath;
            if (docTypeId != null)
                filePath = Path.Combine(Convert.ToString(typeId), Convert.ToString(docTypeId), (inOutPut == 0 ? "input" : "output"), $"{Guid.NewGuid()}.{extension}");
            else
                filePath = Path.Combine(Convert.ToString(typeId), (inOutPut == 0 ? "input" : "output"), $"{Guid.NewGuid()}.{extension}");
            return filePath.Replace("\\", "/"); ;
        }
        public void FileMove(string fromFilePath, string toFilePath)
        {
            using (var ftpClient = CreateFtpClient())
            {
                ftpClient.MoveFile(fromFilePath, toFilePath);
            }
        }

        public void FileCopy(string fromFilePath, string toFilePath)
        {
            using (var ftpClient = CreateFtpClient())
            {
                var openRead = ftpClient.OpenRead(fromFilePath);
                ftpClient.Upload(openRead, toFilePath);
            }
            File.Copy(fromFilePath, toFilePath);
        }

        public Stream GetFileData(string filePath)
        {
            using (var ftpClient = CreateFtpClient())
            {
                var openRead = ftpClient.OpenRead(filePath);
                return openRead;
            }
        }

        private FtpClient CreateFtpClient()
        {
            var result = new FtpClient(rootPath);
            result.Credentials = new NetworkCredential("test", "111111a@");
            return result;
        }
    }
}
