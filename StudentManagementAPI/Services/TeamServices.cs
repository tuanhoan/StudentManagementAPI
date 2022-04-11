using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class TeamServices
    {
        readonly IDbContextFactory<StudentManagementContext> _contextFactory;
        public TeamServices(IDbContextFactory<StudentManagementContext> context)
        {
            _contextFactory = context;
        }
        public async Task AddRangeAsync(List<Teams> teams)
        {
            using var context = _contextFactory.CreateDbContext();
             context.Teams.AddRange(teams);
            await context.SaveChangesAsync();
        }
        public async Task<List<Teams>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Teams.ToListAsync();
        }
    }
}
