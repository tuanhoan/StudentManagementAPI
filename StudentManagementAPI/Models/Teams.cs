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
            Teachers = new HashSet<Teachers>();
            MapTeacherSubjectTeams = new HashSet<MapTeacherSubjectTeam>();
        }
        public int Id { get; set; }
        public string Name { get; set; }   
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public virtual ICollection<Teachers> Teachers { get; set; }
        public virtual ICollection<MapTeacherSubjectTeam> MapTeacherSubjectTeams { get; set; }
    }
}
