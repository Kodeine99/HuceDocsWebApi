using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.ChungTu;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.Services.ChungTu
{
    public interface ITheSinhVienService
    {
        ApiResult<int> Create(THE_SINH_VIEN_VM model);

        ApiResult<bool> Update(THE_SINH_VIEN_VM model);

        ApiResult<List<THE_SINH_VIEN_VM>> GetAll(ChungTuBaseFilter filter, int userId);
        ApiResult<List<THE_SINH_VIEN_VM>> AdminGetAll(ChungTuBaseFilter filter);

        ApiResult<THE_SINH_VIEN_VM> GetById(int id);
    }
}
