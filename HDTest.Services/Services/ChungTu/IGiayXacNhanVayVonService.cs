using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.ChungTu;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.Services.ChungTu
{
    public interface IGiayXacNhanVayVonService
    {
        ApiResult<int> Create(GIAY_XAC_NHAN_VAY_VON_VM model);

        ApiResult<bool> Update(GIAY_XAC_NHAN_VAY_VON_VM model);

        ApiResult<List<GIAY_XAC_NHAN_VAY_VON_VM>> GetAll(ChungTuBaseFilter filter, int userId);
        ApiResult<List<GIAY_XAC_NHAN_VAY_VON_VM>> AdminGetAll(ChungTuBaseFilter filter);

        ApiResult<GIAY_XAC_NHAN_VAY_VON_VM> GetById(int id);
    }
}
