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
        public async Task<IActionResult> CreateNewsFeed([FromForm] CommentDto commentDto, IFormFile formFile)
        {
            await _commentService.AddComment(commentDto, formFile);
            return Ok();
        }

        [HttpGet]
        public async Task<List<Comment>> GetCommentsAsync()
        {
            return await _commentService.GetAllAsync();
        }
    }
}
