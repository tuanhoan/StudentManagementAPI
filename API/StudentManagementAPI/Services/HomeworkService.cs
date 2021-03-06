using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Dto;
using StudentManagementAPI.Enums;
using StudentManagementAPI.Extensions;
using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class HomeworkService
    {
        private IWebHostEnvironment _hostingEnvironment;
        private readonly StudentManagementContext _context;
        private readonly IMapper _mapper;

        public HomeworkService(IWebHostEnvironment environment,
            StudentManagementContext context,
            IMapper mapper)
        {
            _hostingEnvironment = environment;
            _context = context;
            _mapper = mapper;
        }


        public async Task AddHomework(HomeworkDto homework, IFormFileCollection formFiles)
        {
            var entity = _mapper.Map<Homework>(homework);
            var result = _context.Homeworks.Add(entity);
            List<string> sources = new List<string>();
            foreach (var file in formFiles)
            {
                var source = file.FileName;
                sources.Add(source);
            }

            result.Entity.Source = sources.ToArray();

            await _context.SaveChangesAsync();
            await SourcePath.SaveFileAsync(formFiles, PathEnum.Homework.ToString(), result.Entity.Id.ToString());
        }

        public async Task<List<Homework>> GetAllAsync()
        {
            return await _context.Homeworks.OrderByDescending(x => x.CreateAt).ToListAsync();
        }


        public async Task<List<Homework>> GetByTeamId(int teamId)
        {
            var rs = await _context.Homeworks
                .Where(x => x.TeamId == teamId)
                .Include(x => x.UserNavigation)
                .AsNoTracking()
                .OrderByDescending(x => x.CreateAt).ToListAsync();

            return rs;
        }

        public async Task<List<Homework>> GetBySubjectId(int subjectId, int teamId)
        {
            var rs = await _context.Homeworks
                .Include(x => x.UserNavigation)
                    .ThenInclude(x => x.TeacherNavigation)
                    .ThenInclude(x => x.SubjectNavigation)
                .Include(x => x.TeamNavigation)
                .Where(x => x.UserNavigation.TeacherNavigation.SubjectNavigation.Id == subjectId && x.TeamNavigation.Id == teamId)
                .AsNoTracking()
                .OrderByDescending(x => x.CreateAt).ToListAsync();

            return rs;
        }

        public async Task<Homework> GetById(int id)
        {
            return await _context.Homeworks
               .Where(x => x.Id == id)
               .Include(x => x.UserNavigation)
               .AsNoTracking()
               .FirstOrDefaultAsync();

        }
    }
}
