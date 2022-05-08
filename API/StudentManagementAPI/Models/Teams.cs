using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class Teams
    {
        public Teams()
        {
            //Teachers = new HashSet<Teachers>();
            MapTeacherSubjectTeams = new HashSet<MapTeacherSubjectTeam>();
            Students = new HashSet<Students>();
        }
        public int Id { get; set; }
        public string Name { get; set; }   
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } 
        public int? TeacherId { get; set; }
        public Teachers TeachersNavigation { get; set; }
        //public virtual ICollection<Teachers> Teachers { get; set; }
        public virtual ICollection<MapTeacherSubjectTeam> MapTeacherSubjectTeams { get; set; }
        public virtual ICollection<Students> Students { get; set; }
    }
}
