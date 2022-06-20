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
    public class GiayXacNhanToeicServices : IGiayXacNhanToeicService
    {
        private readonly UnitOfWork work;
        private readonly IUserService _userService;

        public GiayXacNhanToeicServices(IUserService userService)
        {
            work = UnitOfWork.GetDefaultInstance();
            _userService = userService;
        }

        public ApiResult<int> Create(GIAY_XAC_NHAN_TOEIC_VM model)
        {

            var newGiayXacNhanToeic = new GIAY_XAC_NHAN_TOEIC()
            {
                TICKET_ID = model.TICKET_ID,
                USER_CREATE = model.USER_CREATE,
                CREATE_DATE = model.CREATE_DATE,
                UPDATE_DATE = model.UPDATE_DATE,
                STATUS = model.STATUS,
                HO_TEN = model.HO_TEN,
                NGAY_SINH = model.NGAY_SINH,
                MSSV = model.MSSV,
                LOP = model.LOP,
                NGANH_HOC = model.NGANH_HOC,
                HE_DAO_TAO = model.HE_DAO_TAO,
                KHOA = model.KHOA,
                DIEM_THI = model.DIEM_THI,
                DOT_THI = model.DOT_THI,
                NGAY_XAC_NHAN = model.NGAY_XAC_NHAN,
        };

            var id = work.GGIAY_XAC_NHAN_TOEICRepository.Create(newGiayXacNhanToeic);

            return new ApiSuccess<int>("Tạo mới thành công") { IsOk = true, Result = id };

        }

        public ApiResult<bool> Update(GIAY_XAC_NHAN_TOEIC_VM model)
        {
            try
            {
                var isUpdated = work.GGIAY_XAC_NHAN_TOEICRepository.Entities
                    .Where(o => o.Id == model.Id)
                    .Update(o => new GIAY_XAC_NHAN_TOEIC
                    {
                  
                        UPDATE_DATE = model.UPDATE_DATE,
                        STATUS = model.STATUS,
                        HO_TEN = model.HO_TEN,
                        NGAY_SINH = model.NGAY_SINH,
                        MSSV = model.MSSV,
                        LOP = model.LOP,
                        NGANH_HOC = model.NGANH_HOC,
                        HE_DAO_TAO = model.HE_DAO_TAO,
                        KHOA = model.KHOA,
                        DIEM_THI = model.DIEM_THI,
                        DOT_THI = model.DOT_THI,
                        NGAY_XAC_NHAN = model.NGAY_XAC_NHAN,
                        NDXN = model.NDXN,

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

        public ApiResult<List<GIAY_XAC_NHAN_TOEIC_VM>> GetAll(ChungTuBaseFilter filter, int userId)
        {
            string username = _userService.GetUserById(userId).UserName;
            var result = work.GGIAY_XAC_NHAN_TOEICRepository.Entities
                .Where(o => o.USER_CREATE == username)
                .Include(o => o.OCR_Request)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.TICKET_ID == null || o.TICKET_ID == filter.TICKET_ID)
                .Where(o => filter.FROM_DATE == null || o.CREATE_DATE > filter.FROM_DATE)
                .Where(o => filter.TO_DATE == null || o.CREATE_DATE < filter.TO_DATE)
                .Select(model => new GIAY_XAC_NHAN_TOEIC_VM(model)
                {

                })
                .ToList();


            return new ApiSuccess<List<GIAY_XAC_NHAN_TOEIC_VM>> { Result = result };
        }

        public ApiResult<List<GIAY_XAC_NHAN_TOEIC_VM>> AdminGetAll(ChungTuBaseFilter filter)
        {
            var result = work.GGIAY_XAC_NHAN_TOEICRepository.Entities
                .Include(o => o.OCR_Request)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.TICKET_ID == null || o.TICKET_ID == filter.TICKET_ID)
                .Where(o => filter.FROM_DATE == null || o.CREATE_DATE > filter.FROM_DATE)
                .Where(o => filter.TO_DATE == null || o.CREATE_DATE < filter.TO_DATE)
                .Select(model => new GIAY_XAC_NHAN_TOEIC_VM(model)
                {

                })
                .ToList();


            return new ApiSuccess<List<GIAY_XAC_NHAN_TOEIC_VM>> { Result = result };
        }


        public ApiResult<GIAY_XAC_NHAN_TOEIC_VM> GetById(int id)
        {
            var GiayXacNhanToeic = work.GGIAY_XAC_NHAN_TOEICRepository.Entities
                .Where(o => o.Id == id)
                .Include(o => o.OCR_Request)
                .Select(o => new GIAY_XAC_NHAN_TOEIC_VM
                {
                    TICKET_ID = o.TICKET_ID
                }).ToList()
                .FirstOrDefault();

            return new ApiSuccess<GIAY_XAC_NHAN_TOEIC_VM> { Result = GiayXacNhanToeic };
        }
    }
}
