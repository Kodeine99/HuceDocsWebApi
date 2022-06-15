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
    public interface IFileManagerService
    {
        string CreateRelativeFilePath(int userId, int typeId, int inOutPut, string extension);
        string CreateFullLocalPath(int userId, int typeId, int inOutPut, string extension);
        string CreateNewTempPath(string extension);
        bool CheckIfFileExist(string relativeFilePath);
        void DeleteFile(string relativeFilePath);
        Stream GetFileData(string relativeFilePath);
        string GetFullFilePath(string relativeFilePath);
        Task CreateFile(int userId, int typeId, int inOutPut, string extension, IFormFile file);
        Task CreateFile(string relativeFilePath, IFormFile file);

        Task<string> UploadFilesToStorageFolder( IList<IFormFile> files); 

    }
}
