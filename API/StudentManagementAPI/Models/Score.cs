using System;

namespace StudentManagementAPI.Models
{
    public class Score
    {
        public DateTime CreatedAt { get; set; }
        public int StudentId { get; set; }
        public int SemesterId { get; set; }
        public int TestTypeId { get; set; }
        public int SubjectId { get; set; }
        public double Point { get; set; }
        public virtual Semester SemesterNavigation { get; set; }
        public virtual TestType TestTypeNavigation { get; set; }
        public virtual Subjects SubjectNavigation { get; set; }
        public virtual Students StudentNavigation { get; set; }
    }
}
