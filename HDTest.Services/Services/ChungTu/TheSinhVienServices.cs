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
    public class TheSinhVienServices : ITheSinhVienService
    {
        private readonly UnitOfWork work;
        private readonly IUserService _userService;

        public TheSinhVienServices(IUserService userService)
        {
            work = UnitOfWork.GetDefaultInstance();
            _userService = userService;
        }

        public ApiResult<int> Create(THE_SINH_VIEN_VM model)
        {

            var newTheSinhVien = new THE_SINH_VIEN()
            {
                TICKET_ID = model.TICKET_ID,
                HUCEDOCS_TYPE = model.HUCEDOCS_TYPE,
                USER_CREATE = model.USER_CREATE,
                CREATE_DATE = model.CREATE_DATE,
                UPDATE_DATE = model.CREATE_DATE,
                STATUS = model.STATUS,

                HO_TEN = model.HO_TEN,
                NGAY_SINH = model.NGAY_SINH,
                MSSV = model.MSSV,
                LOP = model.LOP,
                
                KHOA = model.KHOA,
                HKTT = model.HKTT,
                EMAIL = model.EMAIL,
                KHOA_HOC = model.KHOA_HOC,
                
            };

            var id = work.TTHE_SINH_VIENRepository.Create(newTheSinhVien);

            return new ApiSuccess<int>("Tạo mới thành công") { IsOk = true, Result = id };

        }

        public ApiResult<bool> Update(THE_SINH_VIEN_VM model)
        {
            try
            {
                var isUpdated = work.TTHE_SINH_VIENRepository.Entities
                    .Where(o => o.Id == model.Id)
                    .Update(o => new THE_SINH_VIEN
                    {

                        UPDATE_DATE = DateTime.Now,
                        STATUS = model.STATUS,
                        HO_TEN = model.HO_TEN,
                        NGAY_SINH = model.NGAY_SINH,
                        MSSV = model.MSSV,
                        LOP = model.LOP,
                        KHOA = model.KHOA,
                        HKTT = model.HKTT,
                        EMAIL = model.EMAIL,
                        KHOA_HOC = model.KHOA_HOC,

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

        public ApiResult<List<THE_SINH_VIEN_VM>> GetAll(ChungTuBaseFilter filter, int userId)
        {
            string username = _userService.GetUserById(userId).UserName;
            var result = work.TTHE_SINH_VIENRepository.Entities
                .Where(o => o.USER_CREATE == username)
                .Include(o => o.OCR_Request)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.TICKET_ID == null || o.TICKET_ID == filter.TICKET_ID)
                .Where(o => filter.FROM_DATE == null || o.CREATE_DATE > filter.FROM_DATE)
                .Where(o => filter.TO_DATE == null || o.CREATE_DATE < filter.TO_DATE)
                .OrderByDescending(o => o.CREATE_DATE)
                .Select(model => new THE_SINH_VIEN_VM(model)
                {

                })
                .ToList();


            return new ApiSuccess<List<THE_SINH_VIEN_VM>> { Result = result };
        }

        public ApiResult<List<THE_SINH_VIEN_VM>> AdminGetAll(ChungTuBaseFilter filter)
        {
            var result = work.TTHE_SINH_VIENRepository.Entities
                .Include(o => o.OCR_Request)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.TICKET_ID == null || o.TICKET_ID == filter.TICKET_ID)
                .Where(o => filter.FROM_DATE == null || o.CREATE_DATE > filter.FROM_DATE)
                .Where(o => filter.TO_DATE == null || o.CREATE_DATE < filter.TO_DATE)
                .OrderByDescending(o => o.CREATE_DATE)
                .Select(model => new THE_SINH_VIEN_VM(model)
                {

                })
                .ToList();


            return new ApiSuccess<List<THE_SINH_VIEN_VM>> { Result = result };
        }


        public ApiResult<THE_SINH_VIEN_VM> GetById(int id)
        {
            var TheSinhVien = work.TTHE_SINH_VIENRepository.Entities
                .Where(o => o.Id == id)
                .Include(o => o.OCR_Request)
                .Select(o => new THE_SINH_VIEN_VM
                {
                    TICKET_ID = o.TICKET_ID
                }).ToList()
                .FirstOrDefault();

            return new ApiSuccess<THE_SINH_VIEN_VM> { Result = TheSinhVien };
        }

        public ApiResult<bool> Delete(int docId)
        {
            try
            {
                work.TTHE_SINH_VIENRepository.Entities
                    .Where(o => o.Id == docId)
                    .Update(o => new THE_SINH_VIEN
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
