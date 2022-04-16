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
    public class TeamsController : ControllerBase
    {
        private readonly TeamServices _teamServices;
        public TeamsController(TeamServices teamServices)
        {
            _teamServices = teamServices;
        }
        [HttpGet]
        public async Task<List<Teams>> GetAll()
        {
            return await _teamServices.GetAllAsync();
        }
    }
}
