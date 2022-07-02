using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.ChungTu;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.Services.ChungTu
{
    public interface IGiayCamKetTraNoService
    {
        ApiResult<int> Create(GIAY_CAM_KET_TRA_NO_VM model);

        ApiResult<bool> Update(GIAY_CAM_KET_TRA_NO_VM model);

        ApiResult<List<GIAY_CAM_KET_TRA_NO_VM>> GetAll(ChungTuBaseFilter filter, int userId);
        ApiResult<List<GIAY_CAM_KET_TRA_NO_VM>> AdminGetAll(ChungTuBaseFilter filter);

        ApiResult<GIAY_CAM_KET_TRA_NO_VM> GetById(int id);
        ApiResult<bool> Delete(int docId);

    }
}
