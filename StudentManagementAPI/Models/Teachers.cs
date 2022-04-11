using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class Teachers
    {
        public Teachers()
        {
            MapTeacherSubjectTeams = new HashSet<MapTeacherSubjectTeam>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasChildren { get; set; }
        public string? SkipDay { get; set; }
        public int? TeamId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual Teams? TeamNavigation { get; set; }
        public virtual ICollection<MapTeacherSubjectTeam> MapTeacherSubjectTeams { get; set; }
    }
}
