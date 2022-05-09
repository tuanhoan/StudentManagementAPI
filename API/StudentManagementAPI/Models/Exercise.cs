using System;
using System.Collections.Generic;

namespace StudentManagementAPI.Models
{
    public class Exercise
    {
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int HomeworkId { get; set; }
        public string Content { get; set; }
        public string[] Sources { get; set; }
        public virtual AppUser UserNavigation { get; set; }
        public virtual Homework HomeworkNavigation { get; set; }
    }
     
}
