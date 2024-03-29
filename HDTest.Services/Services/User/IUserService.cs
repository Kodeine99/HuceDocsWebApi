﻿using HuceDocs.Data.Models;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModel.Filter;
using HuceDocs.Services.ViewModels.Common;
using HuceDocs.Services.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HuceDocs.Services.Services
{
    public interface IUserService
    {
        Task<ApiResult<RegisterResult>> RegisterAsync(RegisterRequest request, string confirmationLink);
        Task<ApiResult<RegisterResult>> RegisterAsync2(RegisterRequest request);
        Task<ApiResult<UserTokenResult>> AdminRegisterAsync(RegisterRequest request, string confirmationLink);
        Task<bool> ConfirmEmail(string token, string email);
        Task<ApiResult<UserTokenResult>> LoginAsync(Login model);
        Task<ApiResult<UserTokenResult>> ForgetPasswordAsync(ForgotPaswordViewModel model, string passwordResetLink);
        Task<ApiResult<bool>> ResetPasswordAsync(ResetPasswordViewModel model);
        Task<ApiResult<Pagination<UserViewModel>>> GetUsersAsync(UserFilter filter);
        Task<ApiResult<List<UserViewModel>>> GetAllUserAsync(UserFilterWithoutPagi filter);
        Task<List<ListUsernames>> GetListUsernames();
        ApiResult<bool> UpdateUser(UserViewModel model, int id);
        ApiResult<bool> UpdateMemberActive(updateActiveReq request, int memberId);
        UserViewModel GetUserById(int id);
        ApiResult<Pagination<UserViewModel>> FilterUser(UserFilter filter);
        bool ValidateEmailFormat(string email);
        Task<ApiResult<bool>> CheckPassword(CheckPasswordVM model);
        Task<ApiResult<bool>> ChangePassword(ChangePasswordVM model, string userId);
        Task<ApiResult<CreateUserResult>> AddNewUser(AddNewUserReq req);
    }
}