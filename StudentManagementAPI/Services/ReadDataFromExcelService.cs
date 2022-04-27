using OfficeOpenXml;
using StudentManagementAPI.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class ReadDataFromExcelService
    {
        private readonly TeamServices _teamServices;
        private readonly TeacherServices _teacherServices;
        private readonly SubjectServices _subjectServices;
        private readonly MapTeacherSubjectTeamServices _mapTeacherSubjectTeamServices;

        public static List<string> dsLop;
        public static List<string> dsGiaoVien;
        public static List<string> dsMonHoc;
        public static List<MapTeacherSubjectTeam> MapTeacherSubjectTeams;
       
        public ReadDataFromExcelService(TeacherServices teacherServices,
            TeamServices teamServices,
            SubjectServices subjectServices,
            MapTeacherSubjectTeamServices mapTeacherSubjectTeamServices)
        {
            _teamServices = teamServices;
            _teacherServices = teacherServices;
            _subjectServices = subjectServices;
            _mapTeacherSubjectTeamServices = mapTeacherSubjectTeamServices;
        }

        public List<DuLieu> ReadData()
        {
            dsLop = new List<string>();
            dsGiaoVien = new List<string>();
            dsMonHoc = new List<string>();
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            var path = @"C:\Users\tuanHoan\Downloads\tkb.xlsx";
            FileInfo fileInfo = new FileInfo(path);

            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

            // get number of rows and columns in the sheet
            int rows = worksheet.Dimension.Rows; // 20
            int columns = worksheet.Dimension.Columns; // 7


            List<Teachers> teachers = new List<Teachers>();
            List<DuLieu> list = new List<DuLieu>();
            for (int i = 2; i <= rows; i++)
            {
                for (int j = 3; j <= columns; j++)
                {
                    var value = Regex.Replace(worksheet.Cells[i, j].Value?.ToString(), @"\s+", " ").Split(" ");
                    if (value.Count() < 2) continue;
                    var data = new DuLieu();
                    data.Subject = value[1];
                    data.Name = value[0];
                    data.Lop = worksheet.Cells[i, 1].Value?.ToString();
                    list.Add(data);
                }
            }
            dsLop = list.Select(x => x.Lop).Distinct().ToList();
            dsGiaoVien = list.Select(x => x.Name).Distinct().ToList();
            dsMonHoc = list.Select(x => x.Subject).Distinct().ToList();
            return list;
        }
        public async Task AddData()
        {
            var datas = ReadData();
            List<Teams> teams = new List<Teams>();
            List<Subjects> subjects = new List<Subjects>();
            List<Teachers> teachers = new List<Teachers>();
            foreach (var item in dsLop)
            {
                var team = new Teams()
                {
                    Name = item
                };
                teams.Add(team);
            }
           
            foreach (var item in dsMonHoc)
            {
                var subject = new Subjects()
                {
                    Name = item
                };
                subjects.Add(subject);
            }
            await _teamServices.AddRangeAsync(teams);
            await _subjectServices.AddRangeAsync(subjects);
            var subjectlist = await _subjectServices.GetAllAsync();
            foreach (var item in dsGiaoVien)
            {
                var subject = datas.Where(x => x.Name == item).FirstOrDefault().Subject;
                var subjectId = subjectlist.Where(x => x.Name == subject).FirstOrDefault().Id;
                var teacher = new Teachers()
                {
                    Name = item,
                    SubjectId = subjectId
                };
                teachers.Add(teacher);
            }
            await _teacherServices.AddRangeAsync(teachers);

        }
        public async Task AddTKB()
        {
            MapTeacherSubjectTeams = new List<MapTeacherSubjectTeam>();

            List<string> DuLieu = new List<string>(); 


            var lops = await _teamServices.GetAllAsync();
            var monhocs = await _subjectServices.GetAllAsync();
            var giaoviens = await _teacherServices.GetAllAsync();

            var list = ReadData();
            var gvlop = list.Select(x => new { x.Name, x.Subject }).Distinct().ToList();

            foreach (var item in gvlop)
            {
                //
                var x = list.Where(x => x.Name == item.Name).ToList().Select(x => x.Lop).Distinct().ToList();
                var y = item.Subject;
                string s = y + "-" + item.Name + "-" + string.Join(",", x);
                DuLieu.Add(s);
            }



            int index = 0;
            foreach (var item in DuLieu)
            {
                index++;
                var data = item.Split("-");
                var lps = data[2].Split(",");
                foreach (var lop in lps)
                {
                    var kq = list.Where(x => x.Subject == data[0] && x.Name == data[1] && x.Lop == lop).ToList();
                    var map = new MapTeacherSubjectTeam();
                    map.SubjectId = monhocs.Where(x => x.Name == data[0]).FirstOrDefault().Id;
                    map.TeacherId = giaoviens.Where(x => x.Name == data[1]).FirstOrDefault().Id;
                    map.TeamId = lops.Where(x => x.Name == lop).FirstOrDefault().Id;
                    map.NumberOfLesson = kq.Count;
                    if (kq.Count > 0)
                        MapTeacherSubjectTeams.Add(map);
                }

            }

            await _mapTeacherSubjectTeamServices.AddRangeAsync(MapTeacherSubjectTeams);
        }

        public class DuLieu
        {
            public string Name { get; set; }
            public string Subject { get; set; }
            public string Lop { get; set; }
        }
    }
}
