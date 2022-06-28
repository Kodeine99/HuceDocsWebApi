using HuceDocs.Services.Services;
using HuceDocs.Services.ViewModel;
using HuceDocs.Data.Models;
using HuceDocs.Services.ViewModel.Filter;
using HuceDocsWebApi.Attributes;
using HuceDocsWebApi.JWT.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuceDocsWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthozirationUtility _utility;
        private readonly UserManager<User> _userManager;

        public UserController(IUserService userService, IAuthozirationUtility utility, UserManager<User> userManager)
        {
            _userService = userService;
            _utility = utility;
            _userManager = userManager;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {

            //string confirmationLink = Url.Action("ConfirmEmail", "User");
            var userVM = await _userService.RegisterAsync2(model);
            // tryen them link
            if (userVM.IsOk == false)
            {
                return BadRequest(userVM);
            }
            return Ok(userVM);
        }

        [HttpPost("admin-register")]
        public async Task<IActionResult> AdminRegister([FromBody] RegisterRequest model)
        {

            var confirmationLink = Url.Action("ConfirmEmail", "Admin");
            var userVM = await _userService.AdminRegisterAsync(model, confirmationLink);
            // tryen them link
            if (userVM.IsOk == false)
            {
                return BadRequest(userVM);
            }
            return Ok(userVM);
        }

        // Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var userVM = await _userService.LoginAsync(model);
            if (userVM == null)
            {
                return BadRequest("Người dùng không tồn tại!");
            }
            if (userVM.IsOk == false)
            {
                return BadRequest(userVM);
            }
            return Ok(userVM);
        }

        // Confirm Email
        [HttpGet("confirmemail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var isConfirm = await _userService.ConfirmEmail(token, email);
            if (isConfirm == false)
                return BadRequest("Confirm email failed!");

            return Ok("Confirm email successfully!");
        }


        // Forgot password
        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPaswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error!");
            }
            var passwordResetLink = Url.Action("ResetPassword", "User");
            var result = await _userService.ForgetPasswordAsync(model, passwordResetLink);
            if (result.IsOk == true)
            {
                return Ok(result);
            };
            return BadRequest(result);
        }

        // Reset password
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordViewModel model)
        {
            var result = await _userService.ResetPasswordAsync(model);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // Get all member
        [HttpPost("getall")]
        [CustomAuthorization(Policy = "admin")]
        public async Task<IActionResult> GetAllUserAsyncWithPagi([FromBody] UserFilter filter)
        {
            var userid = await _utility.GetUserIdAsync(HttpContext); // doc user id tu token
            if ( userid <= 0)
                return Unauthorized();

            var users = await _userService.GetUsersAsync(filter);
            return Ok(users);
        }

        [HttpPost("getallusers")]
        //[CustomAuthorization(Policy = "admin")]
        public async Task<IActionResult> GetAllUserAsync([FromBody] UserFilterWithoutPagi filter)
        {
            var userid = await _utility.GetUserIdAsync(HttpContext); // doc user id tu token
            if (userid <= 0)
                return Unauthorized();

            var users = await _userService.GetAllUserAsync(filter);
            return Ok(users);
        }

        // Get all member without pagination
        [HttpGet("getallusernames")]
        [CustomAuthorization(Policy = "admin")]
        public async Task<IActionResult> GetAllUsernames()
        {
            var userId = await _utility.GetUserIdAsync(HttpContext);
            if ( userId <= 0)

                return Unauthorized();

            var usernames = await _userService.GetListUsernames();
            return Ok(usernames);

        }


        [HttpPost("filter")]
        [CustomAuthorization(Policy = "admin,manager")]
        // Get user by filter
        public IActionResult GetAll([FromBody] UserFilter filter)
        {
            var users = _userService.FilterUser(filter);
            return Ok(users);
        }

        // Gett user by token
        [HttpGet("getuserbytoken")]
        public async Task<IActionResult> GetUserByToken()
        {
            var userid = await _utility.GetUserIdAsync(HttpContext); // doc user id tu token
            if ( userid <= 0) 
                return Unauthorized();

            var user = _userService.GetUserById(userid);
            return Ok(user);
        }

        // Gett user by id
        [HttpGet("getuserbyid")]
        //[CustomAuthorization(Policy = "admin")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var userid = _utility.GetUserIdAsync(HttpContext);
            if (await userid <= 0) return Unauthorized();

            var user =  _userService.GetUserById(id);
            return Ok(user);
        }
        
        // Member Update information
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserViewModel model)
        {
            //  get id of user was loged
            var userid = await _utility.GetUserIdAsync(HttpContext);

            if ( userid <= 0)
                return Unauthorized();

            var result =  _userService.UpdateUser(model, userid);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // Admin deactivate/activate member
        [HttpPut("adminactive/{memberId}")]
        //[CustomAuthorization(Policy = "admin")]
        public async Task<IActionResult> UpdateMemberActive([FromBody] updateActiveReq request, int memberId)
        {
            var userId = await  _utility.GetUserIdAsync(HttpContext);
            if ( userId <= 0)
                return Unauthorized();

            var result = _userService.UpdateMemberActive(request, memberId);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // Change password
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordVM model)
        {
            var userId = await _utility.GetUserIdAsync(HttpContext);
            if ( userId <= 0)
                return Unauthorized();
            string strUserId = userId.ToString();
            var result = await _userService.ChangePassword(model, strUserId);
            if (result.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("abc")]
        public async Task<IActionResult> GetAbc()
        {
            return Ok("Get ok");
        }

        [HttpPost("addnew")]
        [CustomAuthorization(Policy = "admin")]
        public async Task<IActionResult> AddNewUser([FromBody] AddNewUserReq req)
        {
            var user = await _utility.GetUserIdAsync(HttpContext);
            //var x = _userManager.Get
            if (user <= 0)
            {
                return Unauthorized();
            }
            var result = await _userService.AddNewUser(req);
            if (result?.IsOk == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}