using HuceDocs.Data.Repository;
using HuceDocs.Notification.Client;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.Common;
using HuceDocs.Services.ViewModels.Notification;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace HuceDocs.Services
{
    public class NotifyService : INotifyService
    {
        private UnitOfWork work;
        private readonly ILogger<NotifyService> _logger;
        private readonly IMessageHub _messageHub;
        public NotifyService(ILogger<NotifyService> logger, IMessageHub messageHub)
        {
            work = UnitOfWork.GetDefaultInstance();
            _logger = logger;
            _messageHub = messageHub;
        }
        public async Task<ApiResult<int>> CreateAsync(Data.Models.Notification model)
        {
            try
            {
                var id = work.NotificationRepository.Create(model);
                await _messageHub.Send("Notify" + model.UserId, DateTime.Now.ToString());
                return new ApiSuccess<int> { Result = id };
            }
            catch(Exception e) 
            { 
                return new ApiError<int>(); 
            }
        }

        public ApiResult<bool> Delete(int id)
        {
            try
            {
                work.NotificationRepository.Entities.Where(o => o.Id == id).Delete();
                return new ApiSuccess<bool> { Result = true };
            }
            catch { return new ApiError<bool>(); }
        }

        public ApiResult<NotifyViewModel> GetAll(int userid)
        {
            try
            {
                var data = work.NotificationRepository.NoTrackingEntities.Where(o => o.UserId == userid);
                var result = new NotifyViewModel();
                result.SeenList = data.Where(o => o.Seen == true).OrderByDescending(o => o.CreateDate).ToList();
                result.NewList = data.Where(o => o.Seen == false).OrderByDescending(o => o.CreateDate).ToList();
                return new ApiSuccess<NotifyViewModel> { Result= result };
            }
            catch { return new ApiError<NotifyViewModel>(); }
        }

        public async Task<ApiResult<bool>> UpdateAsync(Data.Models.Notification model)
        {
            try
            {
                work.NotificationRepository.Update(model);
                await _messageHub.Send("Notify" + model.UserId, DateTime.Now.ToString());
                return new ApiSuccess<bool> { Result = true };
            }
            catch { return new ApiError<bool>(); }
        }

        public ApiResult<bool> UpdateStatus(int id, int status)
        {
            try
            {
                work.NotificationRepository.Entities.Where(o => o.Id == id).Update(o => new Data.Models.Notification { Status = status });
                return new ApiSuccess<bool> { Result = true };
            }
            catch { return new ApiError<bool>(); }
        }

        public ApiResult<bool> SetSeen(int userid)
        {
            try
            {
                work.NotificationRepository.Entities.Where(o => o.UserId == userid).Update(o => new Data.Models.Notification { Seen = true });
                return new ApiSuccess<bool> { Result = true };
            }
            catch { return new ApiError<bool>(); }
        }
    }
}
