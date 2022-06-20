using HuceDocs.Data.Models;
using HuceDocs.Data.Repository;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels;
using HuceDocs.Services.ViewModels.OcrRequest;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace HuceDocs.Services
{
   
    public class OCR_RequestService : IOCR_RequestService
    {
        private readonly UnitOfWork work;
        private readonly UserManager<User> _userManager;

        public OCR_RequestService(
            UserManager<User> userManager)
        {
            work = UnitOfWork.GetDefaultInstance();
            _userManager = userManager;
        }
        public async Task<ApiResult<bool>> CreateAsync(UpdateOCR_RequestVM request)
        {
            //var userId = 
            var newOcr_RqModel = new OCR_Request()
            {
                Ticket_Id = request.Ticket_Id,
                JsonData = request.JsonData,
                UserId = request.UserId,
                DocumentId = request.DocumentId,
                CreateTime = request.CreateTime,
                Token = request.Token,
                VerifyLink = request.VerifyLink,
                OCR_Status_Code = request.OCR_Status_Code,
            };

            var result =  work.OCR_RequestRepository.Create(newOcr_RqModel);
            if (result > 0)
            {
                return new ApiSuccess<bool>("Tạo OCR request thành công") { IsOk = true};
            }
            return new ApiError<bool>("Failed") { IsOk = false};
        }

        public ApiResult<bool> Update(UpdateOCR_RequestVM request)
        {
            try
            {
                var result = work.OCR_RequestRepository.Entities
                .Where(o => o.Ticket_Id == request.Ticket_Id)
                .Update(o => new OCR_Request
                {
                    JsonData = request.JsonData,
                    UserId = request.UserId,
                    DocumentId = request.DocumentId,
                    CreateTime = request.CreateTime,
                    Token = request.Token,
                    VerifyLink = request.VerifyLink,
                    OCR_Status_Code = request.OCR_Status_Code,
                });
                if (result > 0)
                {
                    return new ApiSuccess<bool>("Update thành công") { IsOk= true};
                }
                return new ApiError<bool>("Update kết quả soát lỗi thất bại") { IsOk = false };
            }
            catch (Exception )
            {

                return new ApiError<bool>("Update kết quả soát lỗi thất bại") { IsOk = false };
            }
        }

        public ApiResult<List<OCR_RequestVM>> GetAll(OCR_RequestFilter filter)
        {

            var result = work.OCR_RequestRepository.Entities
                .Include(o => o.User)
                .Include(o => o.Document)
                .ThenInclude(o => o.HFiles)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.Ticket_Id == null || o.Ticket_Id == filter.Ticket_Id)
                .Where(o => filter.UserId == null || o.UserId == filter.UserId)
                .Where(o => filter.FromDate == null || o.CreateTime > filter.FromDate)
                .Where(o => filter.ToDate == null || o.CreateTime < filter.ToDate)
                .Where(o => filter.OCR_Status_Code == null || o.OCR_Status_Code == filter.OCR_Status_Code)
                .Select(o => new OCR_RequestVM(o)
                {
                    HFiles = o.Document.HFiles
                    .Select(x => new HFileVM(x))
                .ToList()
                }).ToList();

            return new ApiSuccess<List<OCR_RequestVM>> { Result = result };
                
        }

        public ApiResult<List<OCR_RequestVM>> UserGetAll(OCR_RequestFilter filter, int userId)
        {
            var result = work.OCR_RequestRepository.Entities
                .Include(o => o.User)
                .Include(o => o.Document)
                .ThenInclude(o =>o.HFiles)
                .Where(o => o.UserId == userId)
                .Where(o => filter.Ticket_Id == null || o.Ticket_Id == filter.Ticket_Id)
                .Where(o => filter.Id == null || o.Id == filter.Id)
                .Where(o => filter.FromDate == null || o.CreateTime > filter.FromDate)
                .Where(o => filter.ToDate == null || o.CreateTime < filter.ToDate)
                .Where(o => filter.OCR_Status_Code == null || o.OCR_Status_Code == filter.OCR_Status_Code)
                .Select(model => new OCR_RequestVM(model)
                {

                })
                .ToList();

            return new ApiSuccess<List<OCR_RequestVM>> { Result = result };
        }
    }
}
