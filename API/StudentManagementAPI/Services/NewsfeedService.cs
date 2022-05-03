using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class NewsfeedService
    {
        private IWebHostEnvironment _hostingEnvironment;
        private readonly StudentManagementContext _context;

        public NewsfeedService(IWebHostEnvironment environment,
            StudentManagementContext context)
        {
            _hostingEnvironment = environment;
            _context = context;
        }


        public async Task AddNewsfeed(NewsFeed newsFeed,IFormFile formFile)
        {
            var result = _context.NewsFeeds.Add(newsFeed);
            newsFeed.Image = formFile.FileName;
            await _context.SaveChangesAsync();

            var x = _hostingEnvironment.ContentRootPath + "\\Upload\\Newsfeed\\"+result.Entity.Id;
            if (!Directory.Exists(x))
            {
                Directory.CreateDirectory(x);
            }
            //string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            string filePath = Path.Combine(x, formFile.FileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            } 
            Console.WriteLine("");
        }

        public async Task<List<NewsFeed>> GetAllAsync()
        {
           return await _context.NewsFeeds.OrderByDescending(x => x.CreateAt).ToListAsync();
        }
    }
}
