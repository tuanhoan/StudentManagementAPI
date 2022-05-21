using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Dto;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;
using StudentManagementAPI.ViewModel.Users;
using System.Threading.Tasks;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : ControllerBase
    {
        private UserServices _userServices;
        public UsersController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _userServices.Authencate(request);
            if (string.IsNullOrEmpty(result.Item1)) { return BadRequest("UserName or Password incorrect."); }
            return Ok(result);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _userServices.Register(request);
            if (!result) { return BadRequest("Register unsuccessful."); }
            return Ok();
        }

        [HttpGet("{userName}")]
        public async Task<AppUser> GetCurrentUser(string userName)
        {
            return await _userServices.GetCurrentUser(userName);
        }

        [HttpPost("UpdateInfo")]
        public async Task<AppUser> UpdateInfo(Profile profile)
        {
            return await _userServices.UpdateInfo(profile);
        }
        [HttpGet("reset-password")]
        public async Task ResetPass(string userName)
        {
            await _userServices.ResetPassword(userName);
        }
    }
}
