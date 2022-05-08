using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class ScoreService
    {
        readonly StudentManagementContext _context;
        public ScoreService(StudentManagementContext context)
        {
            _context = context;
        }
        public async Task<List<Score>> GetAll()
        {
            return await _context.Scores
                .Include(x => x.StudentNavigation)
                .Include(x => x.TestTypeNavigation)
                .Include(x => x.SubjectNavigation)
                .Include(x => x.SemesterNavigation)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Add(Score score)
        {
            _context.Scores.Add(score);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Score>> GetByStudentId(int studentId, int semesterId)
        {
            return await _context.Scores.Where(x => x.StudentId == studentId && x.SemesterId == semesterId)
                .Include(x => x.TestTypeNavigation)
                .Include(x => x.SubjectNavigation)
                .Include(x => x.SemesterNavigation)
                .Include(x=>x.StudentNavigation)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task GenerateData()
        {
            Random random = new Random();
            var testTypes = await _context.TestTypes.ToListAsync();
            var semesters = await _context.Semesters.ToListAsync();
            var students = await _context.Students.ToListAsync();
            var subjects = await _context.Subjects.ToListAsync();
            List<Score> scores = new List<Score>();

            foreach (var testType in testTypes)
            {
                foreach (var semester in semesters)
                {
                    foreach (var student in students)
                    {
                        foreach (var subject in subjects)
                        {
                            var score = new Score()
                            {
                                TestTypeId = testType.Id,
                                SemesterId = semester.Id,
                                StudentId = student.Id,
                                SubjectId = subject.Id,
                                Point = random.Next(1, 10)
                            };
                            scores.Add(score);
                        }
                    }
                }
            }

            _context.AddRange(scores);
            await _context.SaveChangesAsync();
        }
    }
}
