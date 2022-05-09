using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Dto;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworksController : ControllerBase
    {
        private readonly HomeworkService _homeworkService;
        public HomeworksController(HomeworkService homeworkService)
        {
            _homeworkService = homeworkService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewsFeed([FromForm] HomeworkDto homework,  IFormFileCollection formFiles)
        {
            await _homeworkService.AddHomework(homework, formFiles);
            return Ok();
        }

        [HttpGet]
        public async Task<List<Homework>> GetAll()
        {
            return await _homeworkService.GetAllAsync();
        }
        //[HttpGet("{Id:int}")]
        //public async Task<NewsFeed> GetById(int Id)
        //{
        //    return await _newsfeedService.GetNewsFeedById(Id);
        //}
    }
}
