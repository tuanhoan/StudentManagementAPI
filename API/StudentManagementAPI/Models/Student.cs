using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class Students
    { 
        public Students()
        {
            Scores = new HashSet<Score>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int TeamId { get; set; }
        public virtual Teams TeamNavigation { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
