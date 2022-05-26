using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Dto;
using StudentManagementAPI.Enums;
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
        private readonly IMapper _mapper;
        public ExercisesController(ExerciseService exerciseService,
            IMapper mapper)
        {
            _exerciseService = exerciseService;
            _mapper = mapper;
        }

        [HttpGet("{homeworkId:int}")]
        public async Task<List<ExerciseDto>> GetByHomeworkId(int homeworkId)
        {
            var result = await _exerciseService.GetExerciseByHomeworkId(homeworkId);
            var rs = _mapper.Map<List<ExerciseDto>>(result);
            foreach(var item in rs)
            {
                if (item != null && item.Sources != null)
                {
                    for (int i = 0; i < item.Sources.Count; i++)
                    {
                        item.Sources[i] = $"assets\\uploads\\{PathEnum.Exercise}\\{item.HomeworkId}\\" + item.Sources[i];
                    }
                }
            }
            return rs;
        }

        [HttpPost]
        public async Task AddExercise([FromForm] ExerciseCreateDto exercise, IFormFileCollection formFiles)
        {
            await _exerciseService.AddExercise(exercise, formFiles);
        }
    }
}
