using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace StudentManagementAPI.Models
{
    public class AppUser:IdentityUser<Guid>
    {
        public AppUser()
        {
            Comments = new HashSet<Comment>();
            Exercises = new HashSet<Exercise>();
            Homeworks = new HashSet<Homework>();
        }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public Teachers TeacherNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public string Address { get; set; }
        public string AvatarPath { get; set; }
        public string Sex { get; set; }

        public Students StudentNavigation { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
    }
}
