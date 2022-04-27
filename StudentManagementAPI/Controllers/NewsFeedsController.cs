using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsFeedsController : ControllerBase
    {
        private readonly NewsfeedService _newsfeedService;
        public NewsFeedsController(NewsfeedService newsfeedService)
        {
            _newsfeedService = newsfeedService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewsFeed([FromForm] NewsFeed newsFeed,IFormFile formFile)
        {
            await _newsfeedService.AddNewsfeed(newsFeed, formFile);
            return Ok(); 
        }

        [HttpGet]
        public async Task<List<NewsFeed>> GetNewsFeeds()
        {
            return await _newsfeedService.GetAllAsync();
        }
    }
}
