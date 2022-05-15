using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Dto;
using StudentManagementAPI.Enums;
using StudentManagementAPI.Extensions;
using StudentManagementAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class ExerciseService
    {
        readonly StudentManagementContext _context;
        private readonly IMapper _mapper;
        public ExerciseService(StudentManagementContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Exercise>> GetExerciseByHomeworkId(int homeworkId)
        {
            return await _context.Exercises
                .Where(x=>x.HomeworkId == homeworkId)
                .Include(x=>x.UserNavigation)
                .AsNoTracking()
                .OrderByDescending(x=>x.CreatedAt)
                .ToListAsync();
        }

        public async Task AddExercise(ExerciseDto exerciseDto, IFormFileCollection formFiles)
        {
            var entity = _mapper.Map<Exercise>(exerciseDto);
            var result = _context.Exercises.Add(entity);
            List<string> sources = new List<string>();
            foreach (var file in formFiles)
            {
                var source = file.FileName;
                sources.Add(source);
            }

            var x = PathEnum.Exercise.ToString();
            result.Entity.Sources = sources.ToArray();

            await _context.SaveChangesAsync();
            await SourcePath.SaveFileAsync(formFiles, PathEnum.Exercise.ToString(), result.Entity.HomeworkId);
        }
    }
}
