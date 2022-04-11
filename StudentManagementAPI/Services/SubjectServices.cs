using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class SubjectServices
    {
        readonly IDbContextFactory<StudentManagementContext> _contextFactory;
        public SubjectServices(IDbContextFactory<StudentManagementContext> context)
        {
            _contextFactory = context;
        }
        public async Task AddRangeAsync(List<Subjects> subjects)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Subjects.AddRange(subjects);
            await context.SaveChangesAsync();
        }
        public async Task<List<Subjects>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Subjects.ToListAsync();
        }
    }
}
