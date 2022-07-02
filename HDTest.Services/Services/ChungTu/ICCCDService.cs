using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.ChungTu;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.Services.ChungTu
{
    public interface ICCCDService
    {
        ApiResult<int> Create(CCCD_VM model);

        ApiResult<bool> Update(CCCD_VM model);

        ApiResult<List<CCCD_VM>> GetAll(ChungTuBaseFilter filter, int userId);
        ApiResult<List<CCCD_VM>> AdminGetAll(ChungTuBaseFilter filter);

        ApiResult<CCCD_VM> GetById(int id);

    }
}
