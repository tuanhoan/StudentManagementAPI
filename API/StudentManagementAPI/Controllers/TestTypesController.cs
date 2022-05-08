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
    public class TestTypesController : ControllerBase
    {
        private readonly TestTypeService _testTypeService;
        public TestTypesController(TestTypeService testTypeService)
        {
            _testTypeService = testTypeService;
        }

        [HttpGet]
        public async Task<List<TestType>> GetTypeServicesAsync()
        {
            return await _testTypeService.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TestType testType)
        {
            await _testTypeService.Add(testType);
            return Ok();
        }

    }
}
