using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class TeacherServices
    {
        readonly IDbContextFactory<StudentManagementContext> _contextFactory;
        public TeacherServices(IDbContextFactory<StudentManagementContext> context)
        {
            _contextFactory = context;
        }
        public async Task AddRangeAsync(List<Teachers> teachers)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Teachers.AddRange(teachers);
            await context.SaveChangesAsync();
        }
        public async Task<List<Teachers>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Teachers.ToListAsync();
        }
    }
}
