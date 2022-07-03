using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.ChungTu;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.Services.ChungTu
{
    public interface IDonXinNhapHocService
    {
        ApiResult<int> Create(DON_XIN_NHAP_HOC_VM model);

        ApiResult<bool> Update(DON_XIN_NHAP_HOC_VM model);

        ApiResult<List<DON_XIN_NHAP_HOC_VM>> GetAll(ChungTuBaseFilter filter, int userId);
        ApiResult<List<DON_XIN_NHAP_HOC_VM>> AdminGetAll(ChungTuBaseFilter filter);

        ApiResult<DON_XIN_NHAP_HOC_VM> GetById(int id);
        ApiResult<bool> Delete(int docId);
    }
}
