using System;

namespace StudentManagementAPI.Dto
{
    public class HomeworkDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
    }
}
