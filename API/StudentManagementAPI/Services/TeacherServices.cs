using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class TeacherServices
    {
        readonly StudentManagementContext _context;
        private readonly UserManager<AppUser> _userManager;
        public TeacherServices(StudentManagementContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task AddRangeAsync(List<Teachers> teachers)
        {
            Random r = new Random();
            foreach (var item in teachers)
            {
                var temp = RemoveUnicode(item.Name).ToLower() + r.Next(0, 999);
                var user = new AppUser()
                {
                    UserName = temp,
                    Email = temp + "@gmail.com",
                    FullName = item.Name,
                    Birthday = DateTime.Now
                };
                var result = await _userManager.CreateAsync(user, RemoveUnicode(item.Name).ToLower() + "LTT@2022");
                if (!result.Succeeded)
                {
                    Debug.WriteLine("cxx");
                }
                var rs = await _userManager.FindByNameAsync(user.UserName);
                if (rs != null)
                {
                    item.AppUserId = rs.Id;
                }
            }
            _context.Teachers.AddRange(teachers);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Teachers>> GetAllAsync()
        {

            return await _context.Teachers
                .Include(x=>x.AppUser)
                .Include(x=>x.SubjectNavigation)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Teams>> GetTeams(int teacherId)
        {

            var result =  await _context.MapTeacherSubjectTeams
                .Where(x=>x.TeacherId == teacherId)
                .Include(x => x.TeamNavigation) 
                .AsNoTracking()
                .ToListAsync();
            return result.GroupBy(x=>x.TeamNavigation.Name).Select(x=>x.First().TeamNavigation)
                .OrderBy(x=>x.Name).ToList();
        }

        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }
    }
}
