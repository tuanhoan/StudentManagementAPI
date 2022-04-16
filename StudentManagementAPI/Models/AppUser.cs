using Microsoft.AspNetCore.Identity;
using System;

namespace StudentManagementAPI.Models
{
    public class AppUser:IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public Teachers Teachers { get; set; }
    }
}
