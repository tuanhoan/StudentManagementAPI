using System;

namespace StudentManagementAPI.Dto
{
    public class ExerciseDto
    {
        public Guid UserId { get; set; }
        public int HomeworkId { get; set; }
        public string Content { get; set; }
    }
}
