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
    public class CommentsController : ControllerBase
    {
        private readonly CommentService _commentService;
        public CommentsController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentDto commentDto)
        {
            await _commentService.AddComment(commentDto, null);
            return Ok();
        }

        [HttpGet]
        public async Task<List<Comment>> GetCommentsAsync()
        {
            return await _commentService.GetAllAsync();
        }

        [HttpGet("{Id:int}")]
        public async Task<List<Comment>> GetByNewsfeedId(int Id)
        {
            return await _commentService.GetByNewsFeedId(Id);
        }
    }
}
