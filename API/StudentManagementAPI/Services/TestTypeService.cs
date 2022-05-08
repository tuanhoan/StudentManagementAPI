using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class TestTypeService
    {
        readonly StudentManagementContext _context;
        public TestTypeService(StudentManagementContext context)
        {
            _context = context;
        }
        public async Task<List<TestType>> GetAll()
        {
            return await _context.TestTypes 
                .ToListAsync();
        }

        public async Task Add(TestType testType)
        {
            _context.TestTypes.Add(testType);
            await _context.SaveChangesAsync();
        }
    }
}
