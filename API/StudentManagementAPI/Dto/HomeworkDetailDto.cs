using System;
using System.Collections.Generic;

namespace StudentManagementAPI.Dto
{
    public class HomeworkDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string SubjectName { get; set; }
        public List<string> Sources { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public string UserFullName { get; set; }
        public int TeamId { get; set; }  
    }
}
