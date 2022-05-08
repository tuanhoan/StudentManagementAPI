using System.Collections.Generic;

namespace StudentManagementAPI.Models
{
    public class TestType
    {
        public TestType()
        {
            Scores = new HashSet<Score>();
        }
        public int Id { get; set; }
        public string TestName { get; set; }
        public double ScoreFactor { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
