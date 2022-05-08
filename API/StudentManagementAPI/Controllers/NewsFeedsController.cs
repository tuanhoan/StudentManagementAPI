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
        public async Task<IActionResult> CreateNewsFeed([FromBody] NewsFeed newsFeed)
        {
            await _newsfeedService.AddNewsfeed(newsFeed, null);
            return Ok();
        }

        [HttpGet]
        public async Task<List<NewsFeed>> GetNewsFeeds()
        {
            return await _newsfeedService.GetAllAsync();
        }
        [HttpGet("{Id:int}")]
        public async Task<NewsFeed> GetById(int Id)
        {
            return await _newsfeedService.GetNewsFeedById(Id);
        }
    }
}
