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
    public class SubjectController : ControllerBase
    {
        private readonly SubjectServices _subjectServices;
        public SubjectController(SubjectServices subjectServices)
        {
            _subjectServices = subjectServices;
        }

        [HttpGet]
        public async Task<List<Subjects>> GetSemestersAsync()
        {
            return await _subjectServices.GetAllAsync();
        }

        

    }
}
