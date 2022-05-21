using AutoMapper;
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
    public class ScoresController : ControllerBase
    {
        private readonly ScoreService _scoreService;
        private readonly IMapper _mapper;
        public ScoresController(ScoreService scoreService, IMapper mapper)
        {
            _scoreService = scoreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Score>> GetScoresAsync()
        {
            return await _scoreService.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewsFeed([FromBody] ScoreDto scoreDto)
        {
            var score = _mapper.Map<Score>(scoreDto);
            await _scoreService.Add(score);
            return Ok();
        }

        [HttpGet("subjectId/{subjectId:int}/teamId/{teamId:int}/semester/{semesterId:int}")]
        public async Task<List<ScoreViewDto>> GetBySubjectIdTeamId(int subjectId, int teamId, int semesterId)
        {
            var result = await _scoreService.GetBySubjectIdTeamId(subjectId, teamId, semesterId);
            return _mapper.Map<List<ScoreViewDto>>(result);
        }

        [HttpGet("generateData")]
        public async Task GenerateData()
        {
            await _scoreService.GenerateData();
        }

        [HttpGet("student/{studentId:int}/Semester/{semesterId:int}")]
        public async Task<List<ScoreViewDto>> GetByStudent(int studentId, int semesterId)
        {
            var result =  await _scoreService.GetByStudentId(studentId, semesterId);

            return _mapper.Map<List<ScoreViewDto>>(result);
        }

    }
}
