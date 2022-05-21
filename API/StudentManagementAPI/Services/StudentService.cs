using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using StudentManagementAPI.Dto;
using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            var temp = TeacherServices.RemoveUnicode(studentDto.FullName).ToLower().Replace(" ", "")+studentDto.TeamId + r.Next(0, 999);
            var user = new AppUser()
            {
                UserName = temp,
                Email = studentDto.Email,
                FullName = studentDto.FullName,
                Birthday = studentDto.Birthday,
                Sex = studentDto.Sex
            };
            var result = await _userManager.CreateAsync(user, temp + "LTT@2022");
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.FirstOrDefault().Description);
            }
            var rs = await _userManager.FindByNameAsync(user.UserName);
            if (rs != null)
            {
                await _userManager.AddToRoleAsync(rs, "student");
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

        public async Task UploadFile(IFormFile file, int TeamId)
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            var list = new List<StudentDto>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                

                using (var package = new ExcelPackage(stream))
                {
                    
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                     
                    for (int row = 2; row <= rowCount; row++)
                    {
                        var dateTmp = worksheet.Cells[4, 3].Value?.ToString().Trim();

                        var birthday = DateTime.ParseExact(dateTmp, "dd/MM/yyyy", null);
                        list.Add(new StudentDto
                        {
                            FullName = worksheet.Cells[row, 2].Value?.ToString().Trim(),
                            Birthday = birthday,
                            PhoneNumber = "",
                            Email = "",
                            Sex = worksheet.Cells[row, 4].Value?.ToString().Trim(),
                            TeamId = TeamId
                        });
                    }
                }
            }

            foreach(var item in list)
            {
               await AddStudent(item);
            }
        }

        
    }
}
