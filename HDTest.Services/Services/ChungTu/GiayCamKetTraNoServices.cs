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
    public class GiayCamKetTraNoServices : IGiayCamKetTraNoService
    {
        private readonly UnitOfWork work;
        private readonly IUserService _userService;

        public GiayCamKetTraNoServices(IUserService userService)
        {
            work = UnitOfWork.GetDefaultInstance();
            _userService = userService;
        }

        public ApiResult<int> Create(GIAY_CAM_KET_TRA_NO_VM model)
        {

            var newGiayCamKetTraNo = new GIAY_CAM_KET_TRA_NO()
            {
                TICKET_ID = model.TICKET_ID,
                HUCEDOCS_TYPE = model.HUCEDOCS_TYPE,
                USER_CREATE = model.USER_CREATE,
                CREATE_DATE = model.CREATE_DATE,
                UPDATE_DATE = model.CREATE_DATE,
                STATUS = model.STATUS,

                MAU_SO = model.MAU_SO,
                HO_TEN_SV = model.HO_TEN_SV,
                NGAY_SINH = model.NGAY_SINH,
                NGAY_CAP_CMND = model.NGAY_CAP_CMND,
                NOI_CAP = model.NOI_CAP,
                LOP = model.LOP,
                KHOA = model.KHOA,
                SO_THE_HSSV = model.SO_THE_HSSV,
                NIEN_KHOA = model.NIEN_KHOA,
                LOAI_HINH_DAO_TAO = model.LOAI_HINH_DAO_TAO,
                NGAY_NHAP_HOC = model.NGAY_NHAP_HOC,
                NGAY_RA_TRUONG = model.NGAY_RA_TRUONG,
                MA_TRUONG = model.MA_TRUONG,
                NGUOI_DUNG_TEN = model.NGUOI_DUNG_TEN,
                DIA_CHI_NGUOI_DUNG_TEN = model.DIA_CHI_NGUOI_DUNG_TEN,
                NGAN_HANG_VAY_VON = model.NGAN_HANG_VAY_VON,
                SO_TIEN_BANG_SO = model.SO_TIEN_BANG_SO,
                SO_TIEN_BANG_CHU = model.SO_TIEN_BANG_CHU,
                NGAY_KY = model.NGAY_KY,
        };

            var id = work.GGIAY_CAM_KET_TRA_NORepository.Create(newGiayCamKetTraNo);

            return new ApiSuccess<int>("Tạo mới thành công") { IsOk = true, Result = id };

        }

        public ApiResult<bool> Update(GIAY_CAM_KET_TRA_NO_VM model)
        {
            try
            {
                var isUpdated = work.GGIAY_XAC_NHAN_TOEICRepository.Entities
                    .Where(o => o.Id == model.Id)
                    .Update(o => new GIAY_CAM_KET_TRA_NO
                    {

                        UPDATE_DATE = DateTime.Now,
                        STATUS = model.STATUS,

                        MAU_SO = model.MAU_SO,
                        HO_TEN_SV = model.HO_TEN_SV,
                        NGAY_SINH = model.NGAY_SINH,
                        NGAY_CAP_CMND = model.NGAY_CAP_CMND,
                        NOI_CAP = model.NOI_CAP,
                        LOP = model.LOP,
                        KHOA = model.KHOA,
                        SO_THE_HSSV = model.SO_THE_HSSV,
                        NIEN_KHOA = model.NIEN_KHOA,
                        LOAI_HINH_DAO_TAO = model.LOAI_HINH_DAO_TAO,
                        NGAY_NHAP_HOC = model.NGAY_NHAP_HOC,
                        NGAY_RA_TRUONG = model.NGAY_RA_TRUONG,
                        MA_TRUONG = model.MA_TRUONG,
                        NGUOI_DUNG_TEN = model.NGUOI_DUNG_TEN,
                        DIA_CHI_NGUOI_DUNG_TEN = model.DIA_CHI_NGUOI_DUNG_TEN,
                        NGAN_HANG_VAY_VON = model.NGAN_HANG_VAY_VON,
                        SO_TIEN_BANG_SO = model.SO_TIEN_BANG_SO,
                        SO_TIEN_BANG_CHU = model.SO_TIEN_BANG_CHU,
                        NGAY_KY = model.NGAY_KY,

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

        public ApiResult<List<GIAY_CAM_KET_TRA_NO_VM>> GetAll(ChungTuBaseFilter filter, int userId)
        {
            string username = _userService.GetUserById(userId).UserName;
            var result = work.GGIAY_CAM_KET_TRA_NORepository.Entities
                .Where(o => o.USER_CREATE == username)
                .Include(o => o.OCR_Request)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.TICKET_ID == null || o.TICKET_ID == filter.TICKET_ID)
                .Where(o => filter.FROM_DATE == null || o.CREATE_DATE > filter.FROM_DATE)
                .Where(o => filter.TO_DATE == null || o.CREATE_DATE < filter.TO_DATE)
                .OrderByDescending(o => o.CREATE_DATE)
                .Select(model => new GIAY_CAM_KET_TRA_NO_VM(model)
                {

                })
                .ToList();


            return new ApiSuccess<List<GIAY_CAM_KET_TRA_NO_VM>> { Result = result };
        }

        public ApiResult<List<GIAY_CAM_KET_TRA_NO_VM>> AdminGetAll(ChungTuBaseFilter filter)
        {
            var result = work.GGIAY_CAM_KET_TRA_NORepository.Entities
                .Include(o => o.OCR_Request)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.TICKET_ID == null || o.TICKET_ID == filter.TICKET_ID)
                .Where(o => filter.FROM_DATE == null || o.CREATE_DATE > filter.FROM_DATE)
                .Where(o => filter.TO_DATE == null || o.CREATE_DATE < filter.TO_DATE)
                .OrderByDescending(o => o.CREATE_DATE)
                .Select(model => new GIAY_CAM_KET_TRA_NO_VM(model)
                {

                })
                .ToList();


            return new ApiSuccess<List<GIAY_CAM_KET_TRA_NO_VM>> { Result = result };
        }


        public ApiResult<GIAY_CAM_KET_TRA_NO_VM> GetById(int id)
        {
            var GiayXacNhanToeic = work.GGIAY_CAM_KET_TRA_NORepository.Entities
                .Where(o => o.Id == id)
                .Include(o => o.OCR_Request)
                .Select(o => new GIAY_CAM_KET_TRA_NO_VM
                {
                    TICKET_ID = o.TICKET_ID
                }).ToList()
                .FirstOrDefault();

            return new ApiSuccess<GIAY_CAM_KET_TRA_NO_VM> { Result = GiayXacNhanToeic };
        }

        public ApiResult<bool> Delete(int docId)
        {
            try
            {
                work.GGIAY_CAM_KET_TRA_NORepository.Entities
                    .Where(o => o.Id == docId)
                    .Update(o => new GIAY_CAM_KET_TRA_NO
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
