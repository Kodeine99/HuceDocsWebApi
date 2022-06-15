using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HuceDocs.Services.Services
{
    public interface IHFileService
    {
        Task<ApiResult<int>> CreateAsync(HFileVM model);

        List<HFileVM> GetListFileByDocId(int id);
    }
}
