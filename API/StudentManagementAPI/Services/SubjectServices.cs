using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class SubjectServices
    {
        readonly StudentManagementContext _context;
        public SubjectServices(StudentManagementContext context)
        {
            _context = context;
        }
        public async Task AddRangeAsync(List<Subjects> subjects)
        {
            _context.Subjects.AddRange(subjects);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Subjects>> GetAllAsync()
        { 
            return await _context.Subjects.ToListAsync();
        }
    }
}
