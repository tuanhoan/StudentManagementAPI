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
        }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public Teachers TeacherNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Students StudentNavigation { get; set; } 
    }
}
