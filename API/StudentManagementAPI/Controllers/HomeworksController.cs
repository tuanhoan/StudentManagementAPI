using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Dto;
using StudentManagementAPI.Enums;
using StudentManagementAPI.Extensions;
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
        private readonly IMapper _mapper;
        public HomeworksController(HomeworkService homeworkService,
            IMapper mapper)
        {
            _homeworkService = homeworkService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewsFeed([FromForm] HomeworkDto homework, IFormFileCollection formFiles)
        {
            await _homeworkService.AddHomework(homework, formFiles);
            return Ok();
        }

        [HttpGet]
        public async Task<List<Homework>> GetAll()
        {
            return await _homeworkService.GetAllAsync();
        }
        [HttpGet("teamId/{teamId:int}")]
        public async Task<List<Homework>> GetByTeamId(int teamId)
        {
            return await _homeworkService.GetByTeamId(teamId);
        }
        [HttpGet("{id:int}")]
        public async Task<HomeworkDetailDto> GetById(int id)
        {
            var result = await _homeworkService.GetById(id);
            var rs = _mapper.Map<HomeworkDetailDto>(result);
            if (rs!=null && rs.Sources != null)
            {
                for (int i = 0; i< rs.Sources.Count; i++)
                {
                   rs.Sources[i] = $"assets\\uploads\\{PathEnum.Homework}\\{result.Id}\\" + rs.Sources[i];
                }
            }
            
            return rs;

            //.ForEach(item => item = $"{SourcePath.Path}/{PathEnum.Homework}/{src.Id}")
        }
    }
}
