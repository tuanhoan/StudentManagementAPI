using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Dto;
using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class StudentService
    {
        readonly StudentManagementContext _context;
        private readonly UserManager<AppUser> _userManager;
        public StudentService(StudentManagementContext context,
            UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task AddStudent(StudentDto studentDto)
        {
            Random r = new Random();
            var temp = TeacherServices.RemoveUnicode(studentDto.FullName).ToLower().Replace(" ", "") + r.Next(0, 999);
            var user = new AppUser()
            {
                UserName = temp,
                Email = studentDto.Email,
                FullName = studentDto.FullName,
                Birthday = studentDto.Birthday
            };
            var result = await _userManager.CreateAsync(user, temp + "LTT@2022");
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.FirstOrDefault().Description);
            }
            var rs = await _userManager.FindByNameAsync(user.UserName);
            if (rs != null)
            {
                var student = new Students()
                {
                    AppUserId = rs.Id,
                    Name = user.UserName,
                    TeamId = studentDto.TeamId
                };
                _context.Students.Add(student);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Students>> GetAllAsync()
        {
            return await _context.Students
                .Include(x => x.AppUser)
                .Include(x=>x.TeamNavigation)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Students> GetCurrentUser(Guid userId)
        {
            return await _context.Students
                .Where(x=>x.AppUserId == userId) 
                .Include(x => x.TeamNavigation)
                .AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
