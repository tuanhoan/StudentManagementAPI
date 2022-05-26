using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Controllers;
using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class MapTeacherSubjectTeamServices
    {
        readonly StudentManagementContext _context;
        public MapTeacherSubjectTeamServices(StudentManagementContext context)
        {
            _context = context;
        }
        public async Task AddRangeAsync(List<MapTeacherSubjectTeam> mapTeacherSubjectTeams)
        {
            _context.MapTeacherSubjectTeams.AddRange(mapTeacherSubjectTeams);
            await _context.SaveChangesAsync();
        }
        public async Task<List<MapTeacherSubjectTeam>> GetAllAsync()
        {
            return await _context.MapTeacherSubjectTeams
                .Include(x => x.TeacherNavigation)
                .Include(x => x.TeamNavigation)
                .Include(x => x.SubjectNavigation) 
                .AsNoTracking()
                .ToListAsync();
        }

        public void ProgressData()
        {
            var datas = ThoiKhoaBieuController.DataTKB;
            var matrix = RotateMatrix(datas, 24, 39);
            Random rnd = new Random();
            var hasError = true;
            while (hasError)
            {
                hasError = false;
                for (int i = 0; i < matrix.Count; i++)
                {
                    for (int j = 0; j < matrix[i].Count; j++)
                    {
                        var name = matrix[i][j];
                        if (matrix[i].Where(x => x == name).Count() > 1)
                        {
                            int kq = rnd.Next(0, matrix.Count);
                            var nameRdn = matrix[kq][j];
                            var countRdn = matrix[i].Where(x => x == nameRdn).Count();
                            if (countRdn == 0)
                            {
                                hasError = true;
                                string temp = matrix[i][j];
                                matrix[i][j] = matrix[kq][j];
                                matrix[kq][j] = temp;
                            }
                        }
                    }
                }
            }


            var sss = RotateMatrix(matrix, 39, 24, 1);

            ThoiKhoaBieuController.DataTKB = sss;
        }
        static List<List<string>> RotateMatrix(List<List<string>> matrix, int row, int column, int flag = 0)
        {
            List<List<string>> ret = new List<List<string>>();

            var rs = new string[row, column];

            if (flag == 0)
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    if (matrix[i].Count == 0) continue;
                    for (int j = 0; j < matrix[0].Count; j++)
                    {
                        var x = matrix[i][j];
                        rs[j, i] = matrix[i][j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    if (matrix[i].Count == 0) continue;
                    for (int j = 0; j < matrix[0].Count; j++)
                    {
                        var x = matrix[i][j];
                        rs[j, i] = matrix[i][j];
                    }
                }
            }




            List<string> item = new List<string>();
            List<List<string>> kq = new List<List<string>>();
            foreach (var i in rs)
            {
                item.Add(i.Split("-")[0] + "-" + i.Split("-")[1]);
                if (item.Count == column)
                {
                    kq.Add(item);
                    item = new List<string>();
                }
            }

            return kq;
        }
        public async Task<List<MapTeacherSubjectTeam>> GetByTeacherId(int Id)
        { 
            return await _context.MapTeacherSubjectTeams
                .Where(x=>x.TeacherId == Id)
                .Include(x => x.TeacherNavigation)
                .Include(x => x.TeamNavigation)
                .Include(x => x.SubjectNavigation)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
