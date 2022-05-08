using System;

namespace StudentManagementAPI.Dto
{
    public class Profile
    {
        public Guid Id { get; set; }
        public string fullName { get; set; }
        public string phoneNumber { get; set; }
        public string birthday { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string address { get; set; }
    }
}
