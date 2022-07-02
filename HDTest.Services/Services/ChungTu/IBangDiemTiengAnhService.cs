using HuceDocs.Data.Models;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.ChungTu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HuceDocs.Services.Services.ChungTu
{
    public interface IBangDiemTiengAnhService
    {
        ApiResult<int> Create(BANG_DIEM_TIENG_ANH_VM model);

        ApiResult<bool> Update(BANG_DIEM_TIENG_ANH_VM model);

        ApiResult<List<BANG_DIEM_TIENG_ANH_VM>> GetAll(BANG_DIEM_TIENG_ANH_Filter model, int userId);
        ApiResult<List<BANG_DIEM_TIENG_ANH_VM>> AdminGetAll(BANG_DIEM_TIENG_ANH_Filter filter);

        ApiResult<BANG_DIEM_TIENG_ANH_VM> GetById (int id);
        ApiResult<bool> Delete(int docId);


    }
}
