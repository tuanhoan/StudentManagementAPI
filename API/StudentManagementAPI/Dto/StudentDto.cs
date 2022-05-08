using System;

namespace StudentManagementAPI.Dto
{
    public class StudentDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public int TeamId { get; set; }
    }
}
