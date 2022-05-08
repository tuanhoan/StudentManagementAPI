namespace StudentManagementAPI.Dto
{
    public class ScoreDto
    {
        public int StudentId { get; set; }
        public int SemesterId { get; set; }
        public int TestTypeId { get; set; }
        public int SubjectId { get; set; }
        public double Point { get; set; }
    }
}
