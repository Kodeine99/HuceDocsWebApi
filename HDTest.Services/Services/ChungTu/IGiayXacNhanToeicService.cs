using HuceDocs.Data.Models;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.ChungTu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HuceDocs.Services.Services.ChungTu
{
    public interface IGiayXacNhanToeicService
    {
        ApiResult<int> Create(GIAY_XAC_NHAN_TOEIC_VM model);

        ApiResult<bool> Update(GIAY_XAC_NHAN_TOEIC_VM model);

        ApiResult<List<GIAY_XAC_NHAN_TOEIC_VM>> GetAll(ChungTuBaseFilter filter, int userId);
        ApiResult<List<GIAY_XAC_NHAN_TOEIC_VM>> AdminGetAll(ChungTuBaseFilter filter);

        ApiResult<GIAY_XAC_NHAN_TOEIC_VM> GetById(int id);

    }
}
