using System.Collections.Generic;

namespace StudentManagementAPI.Models
{
    public class Semester
    {
        public Semester()
        {
            Scores = new HashSet<Score>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
