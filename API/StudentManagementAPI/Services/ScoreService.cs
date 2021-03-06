using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using StudentManagementAPI.Dto;
using System.Diagnostics;
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
                .Take(100)
                .ToListAsync();
        }

        public async Task Add(Score score)
        {
            _context.Scores.Add(score);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateScore(List<Score> scores)
        {
            foreach (var item in scores)
            {
                _context.Scores.Update(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<StatistialScore>> Statistical()
        {
            var scores = await _context.Scores
                .Include(x=>x.StudentNavigation)
                .ToListAsync();
            var teams = await _context.Teams.ToListAsync();
            var statistialScores = new List<StatistialScore>();
            foreach (var team in teams)
            {
                var scs = scores.Where(x => x.StudentNavigation.TeamId == team.Id).ToList();
                var data = new StatistialScore()
                {
                    Name = team.Name,
                }; 
                if(scs.Where(x => x.Point < 5).Count() > 0)
                {
                    data.Yeu = (double)scs.Where(x => x.Point < 5).Count() / (double)scs.Count() * (double)100;
                }
                if (scs.Where(x => x.Point >= 5 && x.Point < 6.5).Count() > 0)
                {
                    data.TB = (double)scs.Where(x => x.Point >= 5 && x.Point < 6.5).Count() / (double)scs.Count() * (double)100;
                }
                if (scs.Where(x => x.Point >= 6.5 & x.Point < 8).Count() > 0)
                {
                    data.Kha = (double)scs.Where(x => x.Point >= 6.5 & x.Point < 8).Count() / (double)scs.Count() * (double)100;
                }
                if (scs.Where(x => x.Point >= 8).Count() > 0)
                {
                    data.Gioi = (double)scs.Where(x => x.Point >= 8).Count() / (double)scs.Count() * (double)100;
                }
                statistialScores.Add(data);
            }
            return statistialScores;
        }

        public async Task<List<Score>> GetByStudentId(int studentId, int semesterId)
        {
            return await _context.Scores.Where(x => x.StudentId == studentId && x.SemesterId == semesterId)
                .Include(x => x.TestTypeNavigation)
                .Include(x => x.SubjectNavigation)
                .Include(x => x.SemesterNavigation)
                .Include(x => x.StudentNavigation)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Score>> GetBySubjectIdTeamId(int subjectId, int teamId, int semesterId)
        {
            return await _context.Scores
                .Include(x => x.TestTypeNavigation)
                .Include(x => x.SubjectNavigation)
                .Include(x => x.SemesterNavigation)
                .Include(x => x.StudentNavigation)
                    .ThenInclude(x => x.AppUser)
                .Where(x => x.SubjectId == subjectId && x.StudentNavigation.TeamId == teamId && x.SemesterId == semesterId)
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
