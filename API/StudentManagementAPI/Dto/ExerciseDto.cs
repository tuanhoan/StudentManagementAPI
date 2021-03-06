using System;
using System.Collections.Generic;

namespace StudentManagementAPI.Dto
{
    public class ExerciseDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int HomeworkId { get; set; }
        public string Content { get; set; }
        public List<string> Sources { get; set; }
        public string AvatarPath { get; set; }
    }
}
