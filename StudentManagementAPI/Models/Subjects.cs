using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class Subjects
    {
        public Subjects()
        {
            MapTeacherSubjectTeams = new HashSet<MapTeacherSubjectTeam>();
            Teachers = new HashSet<Teachers>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LabId { get; set; }
        public string? Block { get; set; }
        public bool AvoidLastLesson { get; set; }
        public bool RequriedSpacing { get; set; }
        public int Priority { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; } 
        public virtual ICollection<MapTeacherSubjectTeam> MapTeacherSubjectTeams { get; set; }
        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
