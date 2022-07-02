using HuceDocs.Data.Models;
using HuceDocs.Data.Repository;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.ChungTu;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z.EntityFramework.Plus;

namespace HuceDocs.Services.Services.ChungTu
{
    public class CCCDServices : ICCCDService
    {
        private readonly UnitOfWork work;
        private readonly IUserService _userService;

        public CCCDServices(IUserService userService)
        {
            work = UnitOfWork.GetDefaultInstance();
            _userService = userService;
        }

        public ApiResult<int> Create(CCCD_VM model)
        {

            var newCCCD = new CCCD()
            {
                TICKET_ID = model.TICKET_ID,
                HUCEDOCS_TYPE = model.HUCEDOCS_TYPE,
                USER_CREATE = model.USER_CREATE,
                CREATE_DATE = model.CREATE_DATE,
                UPDATE_DATE = model.CREATE_DATE,
                STATUS = model.STATUS,


                SO = model.SO,
                HO_VA_TEN = model.HO_VA_TEN,
                NGAY_SINH = model.NGAY_SINH,
                GIOI_TINH = model.GIOI_TINH,
                QUOC_TICH = model.QUOC_TICH,
                QUE_QUAN = model.QUE_QUAN,
                NOI_THUONG_TRU = model.NOI_THUONG_TRU,
                CO_GIA_TRI_DEN = model.CO_GIA_TRI_DEN,
                NGAY_CAP = model.NGAY_CAP,
                NGUOI_KY = model.NGUOI_KY,
            };

            var id = work.CCCCDRepository.Create(newCCCD);

            return new ApiSuccess<int>("Tạo mới thành công") { IsOk = true, Result = id };

        }

        public ApiResult<bool> Update(CCCD_VM model)
        {
            try
            {
                var isUpdated = work.CCCCDRepository.Entities
                    .Where(o => o.Id == model.Id)
                    .Update(o => new CCCD
                    {
                        UPDATE_DATE = DateTime.Now,
                        STATUS = model.STATUS,
                        SO = model.SO,
                        HO_VA_TEN = model.HO_VA_TEN,
                        NGAY_SINH = model.NGAY_SINH,
                        GIOI_TINH = model.GIOI_TINH,
                        QUOC_TICH = model.QUOC_TICH,
                        QUE_QUAN = model.QUE_QUAN,
                        NOI_THUONG_TRU = model.NOI_THUONG_TRU,
                        CO_GIA_TRI_DEN = model.CO_GIA_TRI_DEN,
                        NGAY_CAP = model.NGAY_CAP,
                        NGUOI_KY = model.NGUOI_KY,

                    });

                if (isUpdated > 0)
                {
                    return new ApiSuccess<bool>("Cập nhật thành công");
                }
                else return new ApiError<bool>("Cập nhật thất bại");
            }
            catch (Exception)
            {

                return new ApiError<bool>("Có lỗi xảy ra trong quá trình cập nhật");
            }
        }

        public ApiResult<List<CCCD_VM>> GetAll(ChungTuBaseFilter filter, int userId)
        {
            string username = _userService.GetUserById(userId).UserName;
            var result = work.CCCCDRepository.Entities
                .Where(o => o.USER_CREATE == username)
                .Include(o => o.OCR_Request)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.TICKET_ID == null || o.TICKET_ID == filter.TICKET_ID)
                .Where(o => filter.FROM_DATE == null || o.CREATE_DATE > filter.FROM_DATE)
                .Where(o => filter.TO_DATE == null || o.CREATE_DATE < filter.TO_DATE)
                .OrderByDescending(o => o.CREATE_DATE)
                .Select(model => new CCCD_VM(model)
                {

                })
                .ToList();


            return new ApiSuccess<List<CCCD_VM>> { Result = result };
        }

        public ApiResult<List<CCCD_VM>> AdminGetAll(ChungTuBaseFilter filter)
        {
            var result = work.CCCCDRepository.Entities
                .Include(o => o.OCR_Request)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.TICKET_ID == null || o.TICKET_ID == filter.TICKET_ID)
                .Where(o => filter.FROM_DATE == null || o.CREATE_DATE > filter.FROM_DATE)
                .Where(o => filter.TO_DATE == null || o.CREATE_DATE < filter.TO_DATE)
                .OrderByDescending(o => o.CREATE_DATE)
                .Select(model => new CCCD_VM(model)
                {

                })
                .ToList();


            return new ApiSuccess<List<CCCD_VM>> { Result = result };
        }


        public ApiResult<CCCD_VM> GetById(int id)
        {
            var GiayXacNhanToeic = work.CCCCDRepository.Entities
                .Where(o => o.Id == id)
                .Include(o => o.OCR_Request)
                .Select(o => new CCCD_VM
                {
                    TICKET_ID = o.TICKET_ID
                }).ToList()
                .FirstOrDefault();

            return new ApiSuccess<CCCD_VM> { Result = GiayXacNhanToeic };
        }

        public ApiResult<bool> Delete(int docId)
        {
            try
            {
                work.CCCCDRepository.Entities
                    .Where(o => o.Id == docId)
                    .Update(o => new CCCD
                    {
                        STATUS = 0
                    });
                return new ApiSuccess<bool>("Xoá tài liệu thành công");
            }
            catch (Exception)
            {

                return new ApiError<bool>("Xoá tài liệu thất bại");
            }
        }
    }
}
