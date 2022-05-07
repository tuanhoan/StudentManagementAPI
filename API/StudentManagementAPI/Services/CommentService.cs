using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Dto;
using StudentManagementAPI.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class CommentService
    {
        private IWebHostEnvironment _hostingEnvironment;
        private readonly StudentManagementContext _context; 

        public CommentService(IWebHostEnvironment hostingEnvironment,
            StudentManagementContext context )
        { 
            _context = context;
            _hostingEnvironment = hostingEnvironment; 
        }

        public async Task AddComment(CommentDto commentDto, IFormFile formFile)
        {
            
            var entity = new Comment()
            {
                NewsFeedId = commentDto.NewsFeedId,
                Content = commentDto.Content,
                UserId = commentDto.UserId
            };
            if (formFile != null) { 
            entity.ImgSources = formFile.FileName;
            }
            var result = _context.Comments.Add(entity); 
            await _context.SaveChangesAsync();

            if (formFile != null)
            {
                var x = _hostingEnvironment.ContentRootPath.Replace("API\\StudentManagementAPI\\", "") + "\\angular-13\\src\\assets" + "\\Upload\\Comment\\" + result.Entity.NewsFeedId;
                if (!Directory.Exists(x))
                {
                    Directory.CreateDirectory(x);
                }
                string filePath = Path.Combine(x, formFile.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }
            }
            
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task<List<Comment>> GetByNewsFeedId(int newsfeedId)
        {
            return await _context.Comments.Where(x=>x.NewsFeedId == newsfeedId)
                .Include(x=>x.UserNavigation)
                .AsNoTracking()
                .OrderByDescending(x=>x.CreatedAt)
                .ToListAsync();
        }
    }
}
