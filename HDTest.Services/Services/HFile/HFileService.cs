using HuceDocs.Data.Models;
using HuceDocs.Data.Repository;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuceDocs.Services.Services
{

    public class HFileService : IHFileService {
        private readonly UnitOfWork work;
        private IWebHostEnvironment _hostingEnvironment;


        public HFileService(IWebHostEnvironment hostingEnvironment)
        {
            work = UnitOfWork.GetDefaultInstance();
            _hostingEnvironment = hostingEnvironment;
        }

        // Create HFile
        public ApiResult<int> CreateAsync(HFileVM model)
        {
            var newHFile = new HFile()
            {
                DocumentId = model.DocumentId,
                FileName = model.FileName,
                FileExtension = model.FileExtension,
                FilePath = model.FilePath,
                Status = model.Status,

            };

            var id = work.HFileRepository.Create(newHFile);

            return new ApiSuccess<int>("Create File success") { IsOk= true, Result=id}; 
        }

        // Get HFile By Id
        public List<HFileVM> GetListFileByDocId(int id)
        {
            var hFile = work.HFileRepository.Entities
                .Where(o => o.DocumentId == id)
                .Select(o => new HFileVM(o))
                .ToList();

            return hFile;
        }

        // Upload file to Storage Folder
        public async Task<string> UploadFilesToStorageFolder(IList<IFormFile> files)
        {
            string fileStorage = Path.Combine(_hostingEnvironment.ContentRootPath, "FileStorage");
            Directory.CreateDirectory(fileStorage);
            foreach (IFormFile file in files)
            {
                if (file.Length > 0)
                {
                    string filePath = Path.Combine(fileStorage, file.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return fileStorage;
        }
    }
}
