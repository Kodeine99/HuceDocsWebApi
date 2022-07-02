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
    public class GiayXacNhanVayVonServices : IGiayXacNhanVayVonService
    {
        private readonly UnitOfWork work;
        private readonly IUserService _userService;

        public GiayXacNhanVayVonServices(IUserService userService)
        {
            work = UnitOfWork.GetDefaultInstance();
            _userService = userService;
        }

        public ApiResult<int> Create(GIAY_XAC_NHAN_VAY_VON_VM model)
        {

            var newGiayXacNhanVayVon = new GIAY_XAC_NHAN_VAY_VON()
            {
                TICKET_ID = model.TICKET_ID,
                HUCEDOCS_TYPE = model.HUCEDOCS_TYPE,
                USER_CREATE = model.USER_CREATE,
                CREATE_DATE = model.CREATE_DATE,
                UPDATE_DATE = model.CREATE_DATE,
                STATUS = model.STATUS,


                HO_TEN = model.HO_TEN,
                NGAY_SINH = model.NGAY_SINH,
                GIOI_TINH = model.GIOI_TINH,
                CMND = model.CMND,
                NGAY_CAP_CMND = model.NGAY_CAP_CMND,
                NOI_CAP = model.NOI_CAP,
                MA_TRUONG = model.MA_TRUONG,
                TEN_TRUONG = model.TEN_TRUONG,
                NGANH_HOC = model.NGANH_HOC,
                HE_DT = model.HE_DT,
                SO_KHOA = model.SO_KHOA,
                MSSV = model.MSSV,
                LOP = model.LOP,
                KHOA = model.KHOA,
                NGAY_NHAP_HOC = model.NGAY_NHAP_HOC,
                NGAY_RA_TRUONG = model.NGAY_RA_TRUONG,
                HOC_PHI_MOI_THANG = model.HOC_PHI_MOI_THANG,
                STK = model.STK,
                TAI_NH = model.TAI_NH,
                CM_THUOC_DIEN = model.CM_THUOC_DIEN,
                CM_THUOC_DOI_TUONG = model.CM_THUOC_DOI_TUONG,
        };

            var id = work.GGIAY_XAC_NHAN_VAY_VONRepository.Create(newGiayXacNhanVayVon);

            return new ApiSuccess<int>("Tạo mới thành công") { IsOk = true, Result = id };

        }

        public ApiResult<bool> Update(GIAY_XAC_NHAN_VAY_VON_VM model)
        {
            try
            {
                var isUpdated = work.GGIAY_XAC_NHAN_VAY_VONRepository.Entities
                    .Where(o => o.Id == model.Id)
                    .Update(o => new GIAY_XAC_NHAN_VAY_VON
                    {

                        UPDATE_DATE = DateTime.Now,
                        STATUS = model.STATUS,
                        HO_TEN = model.HO_TEN,
                        NGAY_SINH = model.NGAY_SINH,
                        GIOI_TINH = model.GIOI_TINH,
                        CMND = model.CMND,
                        NGAY_CAP_CMND = model.NGAY_CAP_CMND,
                        NOI_CAP = model.NOI_CAP,
                        MA_TRUONG = model.MA_TRUONG,
                        TEN_TRUONG = model.TEN_TRUONG,
                        NGANH_HOC = model.NGANH_HOC,
                        HE_DT = model.HE_DT,
                        SO_KHOA = model.SO_KHOA,
                        MSSV = model.MSSV,
                        LOP = model.LOP,
                        KHOA = model.KHOA,
                        NGAY_NHAP_HOC = model.NGAY_NHAP_HOC,
                        NGAY_RA_TRUONG = model.NGAY_RA_TRUONG,
                        HOC_PHI_MOI_THANG = model.HOC_PHI_MOI_THANG,
                        STK = model.STK,
                        TAI_NH = model.TAI_NH,
                        CM_THUOC_DIEN = model.CM_THUOC_DIEN,
                        CM_THUOC_DOI_TUONG = model.CM_THUOC_DOI_TUONG,

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

        public ApiResult<List<GIAY_XAC_NHAN_VAY_VON_VM>> GetAll(ChungTuBaseFilter filter, int userId)
        {
            string username = _userService.GetUserById(userId).UserName;
            var result = work.GGIAY_XAC_NHAN_VAY_VONRepository.Entities
                .Where(o => o.USER_CREATE == username)
                .Include(o => o.OCR_Request)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.TICKET_ID == null || o.TICKET_ID == filter.TICKET_ID)
                .Where(o => filter.FROM_DATE == null || o.CREATE_DATE > filter.FROM_DATE)
                .Where(o => filter.TO_DATE == null || o.CREATE_DATE < filter.TO_DATE)
                .OrderByDescending(o => o.CREATE_DATE)
                .Select(model => new GIAY_XAC_NHAN_VAY_VON_VM(model)
                {

                })
                .ToList();


            return new ApiSuccess<List<GIAY_XAC_NHAN_VAY_VON_VM>> { Result = result };
        }

        public ApiResult<List<GIAY_XAC_NHAN_VAY_VON_VM>> AdminGetAll(ChungTuBaseFilter filter)
        {
            var result = work.GGIAY_XAC_NHAN_VAY_VONRepository.Entities
                .Include(o => o.OCR_Request)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.TICKET_ID == null || o.TICKET_ID == filter.TICKET_ID)
                .Where(o => filter.FROM_DATE == null || o.CREATE_DATE > filter.FROM_DATE)
                .Where(o => filter.TO_DATE == null || o.CREATE_DATE < filter.TO_DATE)
                .OrderByDescending(o => o.CREATE_DATE)
                .Select(model => new GIAY_XAC_NHAN_VAY_VON_VM(model)
                {

                })
                .ToList();


            return new ApiSuccess<List<GIAY_XAC_NHAN_VAY_VON_VM>> { Result = result };
        }


        public ApiResult<GIAY_XAC_NHAN_VAY_VON_VM> GetById(int id)
        {
            var GiayXacNhanToeic = work.GGIAY_XAC_NHAN_VAY_VONRepository.Entities
                .Where(o => o.Id == id)
                .Include(o => o.OCR_Request)
                .Select(o => new GIAY_XAC_NHAN_VAY_VON_VM
                {
                    TICKET_ID = o.TICKET_ID
                }).ToList()
                .FirstOrDefault();

            return new ApiSuccess<GIAY_XAC_NHAN_VAY_VON_VM> { Result = GiayXacNhanToeic };
        }
        public ApiResult<bool> Delete(int docId)
        {
            try
            {
                work.GGIAY_XAC_NHAN_VAY_VONRepository.Entities
                    .Where(o => o.Id == docId)
                    .Update(o => new GIAY_XAC_NHAN_VAY_VON
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
