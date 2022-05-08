namespace StudentManagementAPI.Dto
{
    public class ScoreViewDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public int TestTypeId { get; set; }
        public string TestTypeName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public double Point { get; set; }
    }
}
