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
    public class ExercisesController : ControllerBase
    {
        private readonly ExerciseService _exerciseService;
        public ExercisesController(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet("{homeworkId:int}")]
        public async Task<List<Exercise>> GetByHomeworkId(int homeworkId)
        {
            return await _exerciseService.GetExerciseByHomeworkId(homeworkId);
        }

        [HttpPost]
        public async Task AddExercise([FromForm]ExerciseDto exercise, IFormFileCollection formFiles)
        {
            await _exerciseService.AddExercise(exercise, formFiles);
        }    
    }
}
