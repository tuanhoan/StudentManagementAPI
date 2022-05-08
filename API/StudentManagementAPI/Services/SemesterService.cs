using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class SemesterService
    {
        readonly StudentManagementContext _context;
        public SemesterService(StudentManagementContext context)
        {
            _context = context;
        }
        public async Task<List<Semester>> GetAll()
        {
            return await _context.Semesters 
                .ToListAsync();
        }

        public async Task Add(Semester semester)
        {
            _context.Semesters.Add(semester);
            await _context.SaveChangesAsync();
        }
    }
}
