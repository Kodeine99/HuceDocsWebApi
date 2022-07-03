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
    public class DonXinNhapHocServices : IDonXinNhapHocService
    {
        private readonly UnitOfWork work;
        private readonly IUserService _userService;

        public DonXinNhapHocServices(IUserService userService)
        {
            work = UnitOfWork.GetDefaultInstance();
            _userService = userService;
        }

        public ApiResult<int> Create(DON_XIN_NHAP_HOC_VM model)
        {

            var newDonXinNhapHoc = new DON_XIN_NHAP_HOC()
            {
                TICKET_ID = model.TICKET_ID,
                HUCEDOCS_TYPE = model.HUCEDOCS_TYPE,
                USER_CREATE = model.USER_CREATE,
                CREATE_DATE = model.CREATE_DATE,
                UPDATE_DATE = model.CREATE_DATE,
                STATUS = model.STATUS,

                NGUOI_LAP_DON = model.NGUOI_LAP_DON,
                NGAY_SINH = model.NGAY_SINH,
                MSSV = model.MSSV,
                LOP = model.LOP,

                KHOA = model.KHOA,
                NHAP_HOC_TU_KY = model.NHAP_HOC_TU_KY,
                SO_GIAY_PHEP = model.SO_GIAY_PHEP,
                NGAY_NGHI_THEO_GIAY_PHEP = model.NGAY_NGHI_THEO_GIAY_PHEP,
                NGAY_KY = model.NGAY_KY,

            };

            var id = work.DDON_XIN_NHAP_HOCRepository.Create(newDonXinNhapHoc);

            return new ApiSuccess<int>("Tạo mới thành công") { IsOk = true, Result = id };

        }

        public ApiResult<bool> Update(DON_XIN_NHAP_HOC_VM model)
        {
            try
            {
                var isUpdated = work.DDON_XIN_NHAP_HOCRepository.Entities
                    .Where(o => o.Id == model.Id)
                    .Update(o => new DON_XIN_NHAP_HOC
                    {

                        UPDATE_DATE = DateTime.Now,
                        STATUS = model.STATUS,
                        NGUOI_LAP_DON = model.NGUOI_LAP_DON,
                        NGAY_SINH = model.NGAY_SINH,
                        MSSV = model.MSSV,
                        LOP = model.LOP,
                        KHOA = model.KHOA,
                        NHAP_HOC_TU_KY = model.NHAP_HOC_TU_KY,
                        SO_GIAY_PHEP = model.SO_GIAY_PHEP,
                        NGAY_NGHI_THEO_GIAY_PHEP = model.NGAY_NGHI_THEO_GIAY_PHEP,
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

        public ApiResult<List<DON_XIN_NHAP_HOC_VM>> GetAll(ChungTuBaseFilter filter, int userId)
        {
            string username = _userService.GetUserById(userId).UserName;
            var result = work.DDON_XIN_NHAP_HOCRepository.Entities
                .Where(o => o.USER_CREATE == username)
                .Include(o => o.OCR_Request)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.TICKET_ID == null || o.TICKET_ID == filter.TICKET_ID)
                .Where(o => filter.FROM_DATE == null || o.CREATE_DATE > filter.FROM_DATE)
                .Where(o => filter.TO_DATE == null || o.CREATE_DATE < filter.TO_DATE)
                .OrderByDescending(o => o.CREATE_DATE)
                .Select(model => new DON_XIN_NHAP_HOC_VM(model)
                {

                })
                .ToList();


            return new ApiSuccess<List<DON_XIN_NHAP_HOC_VM>> { Result = result };
        }

        public ApiResult<List<DON_XIN_NHAP_HOC_VM>> AdminGetAll(ChungTuBaseFilter filter)
        {
            var result = work.DDON_XIN_NHAP_HOCRepository.Entities
                .Include(o => o.OCR_Request)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.TICKET_ID == null || o.TICKET_ID == filter.TICKET_ID)
                .Where(o => filter.FROM_DATE == null || o.CREATE_DATE > filter.FROM_DATE)
                .Where(o => filter.TO_DATE == null || o.CREATE_DATE < filter.TO_DATE)
                .OrderByDescending(o => o.CREATE_DATE)
                .Select(model => new DON_XIN_NHAP_HOC_VM(model)
                {

                })
                .ToList();


            return new ApiSuccess<List<DON_XIN_NHAP_HOC_VM>> { Result = result };
        }


        public ApiResult<DON_XIN_NHAP_HOC_VM> GetById(int id)
        {
            var DonXinNhapHoc = work.DDON_XIN_NHAP_HOCRepository.Entities
                .Where(o => o.Id == id)
                .Include(o => o.OCR_Request)
                .Select(o => new DON_XIN_NHAP_HOC_VM
                {
                    TICKET_ID = o.TICKET_ID
                }).ToList()
                .FirstOrDefault();

            return new ApiSuccess<DON_XIN_NHAP_HOC_VM> { Result = DonXinNhapHoc };
        }

        public ApiResult<bool> Delete(int docId)
        {
            try
            {
                work.DDON_XIN_NHAP_HOCRepository.Entities
                    .Where(o => o.Id == docId)
                    .Update(o => new DON_XIN_NHAP_HOC
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
