using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Dto;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;
using StudentManagementAPI.ViewModel.Users;
using System;
using System.Threading.Tasks;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : ControllerBase
    {
        private IMapper _mapper;
        private UserServices _userServices;
        public UsersController(UserServices userServices,
            IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
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
        public async Task<UserInfoDto> GetCurrentUser(string userName)
        {
            var rs =  await _userServices.GetCurrentUser(userName);
            return _mapper.Map<UserInfoDto>(rs);
        }

        [HttpPost("UpdateInfo")]
        public async Task<AppUser> UpdateInfo(Dto.Profile profile)
        {
            return await _userServices.UpdateInfo(profile);
        }
        [HttpPost("UpdateAvatar")]
        public async Task<AppUser> UpdateAvatar(IFormFileCollection files, string username)
        {
            return await _userServices.UpdateAvatar(files, username);
        }
        [HttpGet("reset-password")]
        public async Task ResetPass(string userName)
        {
            await _userServices.ResetPassword(userName);
        }
    }
}
