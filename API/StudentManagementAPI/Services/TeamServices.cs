using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class TeamServices
    {
        readonly StudentManagementContext _context;
        public TeamServices(StudentManagementContext context)
        {
            _context = context;
        }
        public async Task AddRangeAsync(List<Teams> teams)
        {
            _context.Teams.AddRange(teams);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Teams>> GetAllAsync()
        { 
            return await _context.Teams.ToListAsync();
        }
    }
}
