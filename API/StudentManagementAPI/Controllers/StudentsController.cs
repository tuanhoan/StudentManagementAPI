using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Dto;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentsController(StudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentDto studentDto)
        {
            await _studentService.AddStudent(studentDto);
            return Ok(studentDto);
        }

        [HttpGet]
        public async Task<List<Students>> GetAll()
        {
            return await _studentService.GetAllAsync();
        }

        [HttpGet("current-student")]
        public async Task<Students> GetCurrentStudent(Guid userId)
        {
            return await _studentService.GetCurrentUser(userId);
        }
    }
}
