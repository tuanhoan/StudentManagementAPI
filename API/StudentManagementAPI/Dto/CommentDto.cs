using System;

namespace StudentManagementAPI.Dto
{
    public class CommentDto
    {
        public Guid UserId { get; set; } 
        public int NewsFeedId { get; set; }
        public string Content { get; set; } 
    }
}
