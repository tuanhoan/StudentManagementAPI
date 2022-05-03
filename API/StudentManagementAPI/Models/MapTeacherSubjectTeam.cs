using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class MapTeacherSubjectTeam
    {
        public int TeacherId { get; set; }
        public int TeamId { get; set; }
        public int SubjectId { get; set; }
        public int NumberOfLesson { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual Teachers TeacherNavigation { get; set; }
        public virtual Teams TeamNavigation { get; set; }
        public virtual Subjects SubjectNavigation { get; set; }
    }
}
