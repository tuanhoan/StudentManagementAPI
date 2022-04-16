using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class TeacherServices
    {
        readonly StudentManagementContext _context;
        public TeacherServices(StudentManagementContext context)
        {
            _context = context;
        }
        public async Task AddRangeAsync(List<Teachers> teachers)
        {
            _context.Teachers.AddRange(teachers);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Teachers>> GetAllAsync()
        { 
            return await _context.Teachers.ToListAsync();
        }
    }
}
