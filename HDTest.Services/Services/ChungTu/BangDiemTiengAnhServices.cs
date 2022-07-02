using HuceDocs.Data.Models;
using HuceDocs.Data.Repository;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.ChungTu;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace HuceDocs.Services.Services.ChungTu
{
    public class BangDiemTiengAnhServices: IBangDiemTiengAnhService

    {
        private readonly UnitOfWork work;
        private readonly IUserService _userService;

        public BangDiemTiengAnhServices(IUserService userService)
        {
            work= UnitOfWork.GetDefaultInstance();
            _userService= userService;
        }

        public ApiResult<int> Create(BANG_DIEM_TIENG_ANH_VM model)
        {
            
            var newBangDiemTiengAnh = new BANG_DIEM_TIENG_ANH()
            {
                TICKET_ID = model.TICKET_ID,
                HUCEDOCS_TYPE = model.HUCEDOCS_TYPE,
                CREATE_DATE = model.CREATE_DATE,
                UPDATE_DATE = model.CREATE_DATE,
                USER_CREATE = model.USER_CREATE,
                STATUS = model.STATUS,
                FULL_NAME = model.FULL_NAME,
                DOB = model.DOB,
                MAJOR = model.MAJOR,
                STUDENT_ID = model.STUDENT_ID,
                S_CLASS = model.S_CLASS,
                TRAINING_FORM = model.TRAINING_FORM,
                GPA_10SCALE = model.GPA_10SCALE,
                GPA_4SCALE = model.GPA_4SCALE,
                TOTAL_CREDITS = model.TOTAL_CREDITS,
                CLASSIFICATION = model.CLASSIFICATION,
                MARK_TABLE = model.MARK_TABLE,
            };

            var id = work.BBANG_DIEM_TIENG_ANHRepository.Create(newBangDiemTiengAnh);

            return new ApiSuccess<int>("Tạo mới thành công") { IsOk = true, Result = id};
        
        }

        public  ApiResult<bool> Update(BANG_DIEM_TIENG_ANH_VM model)
        {
            try
            {
                var isUpdated = work.BBANG_DIEM_TIENG_ANHRepository.Entities
                    .Where(o => o.Id == model.Id)
                    .Update(o => new BANG_DIEM_TIENG_ANH
                    {
                        UPDATE_DATE = DateTime.Now,
                        STATUS = model.STATUS,
                        FULL_NAME = model.FULL_NAME,
                        DOB = model.DOB,
                        MAJOR = model.MAJOR,
                        STUDENT_ID = model.STUDENT_ID,
                        S_CLASS = model.S_CLASS,
                        TRAINING_FORM = model.TRAINING_FORM,
                        GPA_10SCALE = model.GPA_10SCALE,
                        GPA_4SCALE = model.GPA_4SCALE,
                        TOTAL_CREDITS = model.TOTAL_CREDITS,
                        CLASSIFICATION = model.CLASSIFICATION,
                        MARK_TABLE = model.MARK_TABLE,

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

        public ApiResult<List<BANG_DIEM_TIENG_ANH_VM>> GetAll(BANG_DIEM_TIENG_ANH_Filter filter, int userId)
        {
            string username = _userService.GetUserById(userId).UserName;
            var result = work.BBANG_DIEM_TIENG_ANHRepository.Entities
                .Where(o => o.USER_CREATE == username)
                .Include(o => o.OCR_Request)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.TICKET_ID == null || o.TICKET_ID == filter.TICKET_ID)
                .Where(o => filter.FROM_DATE == null || o.CREATE_DATE > filter.FROM_DATE)
                .Where(o => filter.TO_DATE == null || o.CREATE_DATE < filter.TO_DATE)
                .OrderByDescending(o => o.CREATE_DATE)
                .Select(model => new BANG_DIEM_TIENG_ANH_VM(model)
                {

                })
                .ToList();


            return new ApiSuccess<List<BANG_DIEM_TIENG_ANH_VM>>{ Result = result };
        }

        public ApiResult<List<BANG_DIEM_TIENG_ANH_VM>> AdminGetAll(BANG_DIEM_TIENG_ANH_Filter filter)
        {
            var result = work.BBANG_DIEM_TIENG_ANHRepository.Entities
                .Include(o => o.OCR_Request)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.TICKET_ID == null || o.TICKET_ID == filter.TICKET_ID)
                .Where(o => filter.FROM_DATE == null || o.CREATE_DATE > filter.FROM_DATE)
                .Where(o => filter.TO_DATE == null || o.CREATE_DATE < filter.TO_DATE)
                .OrderByDescending(o => o.CREATE_DATE)
                .Select(model => new BANG_DIEM_TIENG_ANH_VM(model)
                {

                })
                .ToList();


            return new ApiSuccess<List<BANG_DIEM_TIENG_ANH_VM>> { Result = result };
        }


        public ApiResult<BANG_DIEM_TIENG_ANH_VM> GetById(int id)
        {
            var BangDiemTiengAnh = work.BBANG_DIEM_TIENG_ANHRepository.Entities
                .Where(o => o.Id == id)
                .Include(o => o.OCR_Request)
                .Select(o => new BANG_DIEM_TIENG_ANH_VM
                {
                    TICKET_ID = o.TICKET_ID
                }).ToList()
                .FirstOrDefault();

            return new ApiSuccess<BANG_DIEM_TIENG_ANH_VM> { Result = BangDiemTiengAnh };
        }
    }
}
