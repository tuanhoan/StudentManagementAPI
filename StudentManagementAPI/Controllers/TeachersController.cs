using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class TeachersController : ControllerBase
    {
        private readonly TeacherServices _teacherServices;
        public TeachersController(TeacherServices teacherServices)
        {
            _teacherServices = teacherServices;
        }
        [HttpGet]
        public async Task<List<Teachers>> GetAll()
        {
            return await _teacherServices.GetAllAsync();
        }
    }
}
