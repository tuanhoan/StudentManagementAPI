using System;

namespace StudentManagementAPI.Models
{
    public class Comment
    {
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int NewsFeedId { get; set; }
        public string Content { get; set; }
        public string ImgSources { get; set; }
        public virtual AppUser UserNavigation { get; set; }
        public virtual NewsFeed NewsFeedNavigation { get; set; }
    }
}
