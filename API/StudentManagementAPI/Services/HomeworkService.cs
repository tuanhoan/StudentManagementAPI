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

            var x = PathEnum.Homework.ToString();
            result.Entity.Source = sources.ToArray();

            await _context.SaveChangesAsync();
            await SourcePath.SaveFileAsync(formFiles, PathEnum.Homework.ToString(), result.Entity.Id);
        }

        public async Task<List<Homework>> GetAllAsync()
        {
            return await _context.Homeworks.OrderByDescending(x => x.CreateAt).ToListAsync();
        }

        public async Task<NewsFeed> GetNewsFeedById(int id)
        {
            var roothPath = "assets\\Upload\\Newsfeed\\" + id;
            var result = await _context.NewsFeeds.FirstOrDefaultAsync(x => x.Id == id);
            result.Image = roothPath + "\\" + result.Image;
            return result;
        }
    }
}
