using HuceDocs.Data.Models;
using HuceDocs.Data.Repository;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuceDocs.Services.Services
{

    public class HFileService : IHFileService {
        private readonly UnitOfWork work;

        public HFileService(IHFileService hFileService)
        {
            work = UnitOfWork.GetDefaultInstance();
        }
    
        // Create HFile
        public  async Task<ApiResult<int>> CreateAsync(HFileVM model)
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
    }
}
