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
    public class SemestersController : ControllerBase
    {
        private readonly SemesterService _semesterService;
        public SemestersController(SemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        [HttpGet]
        public async Task<List<Semester>> GetSemestersAsync()
        {
            return await _semesterService.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Semester semester)
        {
            await _semesterService.Add(semester);
            return Ok();
        }

    }
}
