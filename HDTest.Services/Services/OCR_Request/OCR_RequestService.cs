using HuceDocs.Data.Models;
using HuceDocs.Data.Repository;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.OcrRequest;
using Microsoft.AspNetCore.Identity;
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

        public  ApiResult<bool> Update(UpdateOCR_RequestVM request)
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
    }
}
