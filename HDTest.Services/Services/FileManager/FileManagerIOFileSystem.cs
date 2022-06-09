using HuceDocs.Services.EnumDefine;
using System;
using System.IO;

namespace HuceDocs.Services
{
    public class FileManagerIOFileSystem : IFileManagerIO
    {
        private readonly string rootPath;

        public char DirectorySeparatorChar => Path.DirectorySeparatorChar;

        public FileManagerIOFileSystem(string rootPath)
        {
            this.rootPath = rootPath;
        }

        public bool FileExists(string filePath)
        {
            return File.Exists(GetFullFilePath(filePath));
        }

        public void FileDelete(string filePath)
        {
            var fileFullPath = GetFullFilePath(filePath);
            if (File.Exists(fileFullPath))
                File.Delete(fileFullPath);
        }

        public bool DirectoryExists(string dirPath)
        {
            return Directory.Exists(GetFullFilePath(dirPath));
        }

        public void DirectoryDelete(string dirPath)
        {
            var dirFullPath = GetFullFilePath(dirPath);
            if (Directory.Exists(dirFullPath))
                Directory.Delete(dirFullPath);
        }

        public void DirectoryCreate(string dirPath)
        {
            Directory.CreateDirectory(GetFullFilePath(dirPath));
        }

        public string GetDirectoryPath(string filePath)
        {
            return Path.GetDirectoryName(filePath);
        }

        public string PathCombine(string path1, string path2)
        {
            return Path.Combine(path1, path2);
        }
        public string PathCombine(string path1, string path2, string path3)
        {
            return Path.Combine(path1, path2, path3);
        }

        public string GetFullFilePath(string relativePath)
        {
            return Path.Combine(rootPath, relativePath);
        }

        public string GetFilePath(int userId, int typeId, int inOutPut, string extension)
        {
            if (extension.Substring(0, 1) == ".")
                extension = extension.Substring(1, extension.Length - 1);
            var filePath = Path.Combine(Convert.ToString(userId), Convert.ToString(typeId), (inOutPut == (int)eFolder.input ? "input" : "output"), $"{Guid.NewGuid()}.{extension}");
            return filePath;
        }
        public string GetFileServerAnalysisPath(int typeId, int? docTypeId, int inOutPut, string extension)
        {
            if (extension.Substring(0, 1) == ".")
                extension = extension.Substring(1, extension.Length - 1);
            string filePath;
            if (docTypeId != null)
                filePath = Path.Combine(Convert.ToString(typeId), Convert.ToString(docTypeId), (inOutPut == (int)eFolder.input ? "input" : "output"), $"{Guid.NewGuid()}.{extension}");
            else
                filePath = Path.Combine(Convert.ToString(typeId), (inOutPut == (int)eFolder.input ? "input" : "output"), $"{Guid.NewGuid()}.{extension}");
            return filePath;
        }

        public void FileMove(string fromFilePath, string toFilePath)
        {
            File.Move(fromFilePath, toFilePath);
        }

        public void FileCopy(string fromFilePath, string toFilePath)
        {
            File.Copy(fromFilePath, toFilePath);
        }

        public Stream GetFileData(string filePath)
        {
            return File.OpenRead(GetFullFilePath(filePath));
        }
    } 
}
