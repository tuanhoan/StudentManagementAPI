using System;

namespace StudentManagementAPI.Dto
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarPath { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string IsStudent { get; set; }
        public string BirthDay { get; set; }
        public string Email { get; set; }
        public int? TeamId { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
    }
}
