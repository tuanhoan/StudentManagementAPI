using System;
using System.Collections.Generic;

namespace StudentManagementAPI.Models
{
    public class NewsFeed
    {
        public NewsFeed()
        {
            Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime CreateAt { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
