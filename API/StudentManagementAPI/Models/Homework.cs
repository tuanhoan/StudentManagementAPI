using System;
using System.Collections.Generic;

namespace StudentManagementAPI.Models
{
    public class Homework
    {
        public Homework()
        {
            Exercises = new HashSet<Exercise>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string[] Source { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public AppUser UserNavigation { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
