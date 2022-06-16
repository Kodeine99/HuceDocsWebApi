using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HuceDocs.Services.Services
{
    public interface IHFileService
    {
        ApiResult<int> CreateAsync(HFileVM model);

        List<HFileVM> GetListFileByDocId(int id);

        Task<string> UploadFilesToStorageFolder(IList<IFormFile> files);

    }
}
