using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class ThoiKhoaBieuController : ControllerBase
    {
        private readonly MapTeacherSubjectTeamServices _teacherSubjectTeamServices;
        private readonly TeamServices _teamServices;
        List<List<string>> TKB = new List<List<string>>();
        public static List<List<string>> DataTKB;
        public static List<List<string>> DataTKBBefore;
        public ThoiKhoaBieuController(MapTeacherSubjectTeamServices teacherSubjectTeamServices, TeamServices teamServices)
        {
            _teacherSubjectTeamServices = teacherSubjectTeamServices;
            _teamServices = teamServices;
        }
        [HttpGet("getall")]
        public async Task<List<MapTeacherSubjectTeam>> GetAll()
        {
            return await _teacherSubjectTeamServices.GetAllAsync();
        }
        [HttpGet]
        public async Task<List<List<string>>> GetData()
        {
            var teams = await _teamServices.GetAllAsync();
            var data = await _teacherSubjectTeamServices.GetAllAsync();
            foreach (var team in teams)
            {
                List<string> item = new List<string>();
                var maps = data.Where(x => x.TeamId == team.Id).ToList();
                foreach (var map in maps)
                {
                    for (int i = 0; i < map.NumberOfLesson; i++)
                    {
                        item.Add(map.SubjectNavigation.Name + "-" + map.TeacherNavigation.Name + "-" + team.Name);
                        if (item.Count >= 4)
                        {
                            TKB.Add(item);
                            item = new List<string>();
                        }
                    }
                }
            }


            //rà

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (var excel = new ExcelPackage())
            {
                ExcelWorksheet workSheet;
                excel.Workbook.CalcMode = ExcelCalcMode.Automatic;
                try
                {
                    workSheet = excel.Workbook.Worksheets[0];
                }
                catch
                {
                    excel.Workbook.Worksheets.Add("test");
                    workSheet = excel.Workbook.Worksheets[0];
                    //workSheet.Hidden = OfficeOpenXml.eWorkSheetHidden.Hidden;
                }


                List<List<string>> OneTeam = new List<List<string>>();
                List<List<string>> NewList = new List<List<string>>();
                List<List<string>> listkk = new List<List<string>>();

                int number = 0;
                do
                {
                    OneTeam = TKB.Skip(number).Take(6).ToList();
                    //for(int i = 0; i< OneTeam.Count; i++)
                    //{
                    //    //var x = OneTeam[i];
                    //    //var z = OneTeam[i].Where(k => k == x[0]).Count();
                    //    foreach(var tiet in OneTeam[i])
                    //    {
                    //        var soMon = OneTeam[i].Where(x => x == tiet).Count();
                    //        if (soMon > 1)
                    //        {
                    //            var tempt = tiet;
                    //            var tiet = OneTeam[i + 1][0];

                    //        }
                    //    }
                    //}

                    var mang1chieu = new List<string>();
                    foreach (var item in OneTeam)
                    {
                        foreach (var ik in item)
                        {
                            mang1chieu.Add(ik);
                        }

                    }

                    bool stop = true;
                    while (stop)
                    {
                        for (int i = 0; i < mang1chieu.Count - 1; i++)
                        {
                            var monHoc = mang1chieu[i];
                            for (int j = i + 1; j <= i + 3; j++)
                            {
                                //Các trường hợp cuối
                                if (j + 4 >= mang1chieu.Count)
                                {
                                    if (j >= mang1chieu.Count) continue;
                                    if (monHoc == mang1chieu[j])
                                    {
                                        var temp = mang1chieu[i];
                                        mang1chieu[i] = mang1chieu[mang1chieu.Count - i];
                                        mang1chieu[mang1chieu.Count - i] = temp;
                                    }
                                }
                                else
                                {
                                    if (monHoc == mang1chieu[j])
                                    {
                                        var temp = mang1chieu[i];

                                        if (mang1chieu[i] != mang1chieu[j + 3])
                                        {
                                            mang1chieu[i] = mang1chieu[j + 3];
                                            mang1chieu[j + 3] = temp;
                                        }
                                        else if (mang1chieu[i] != mang1chieu[j + 4])
                                        {
                                            mang1chieu[i] = mang1chieu[j + 4];
                                            mang1chieu[j + 4] = temp;
                                        }
                                        //else
                                        //{
                                        //    mang1chieu[i] = mang1chieu[j + 5];
                                        //    mang1chieu[j + 5] = temp;
                                        //}

                                    }
                                }

                            }
                        }
                        if (mang1chieu.Count > 0)
                        {
                            int error = 0;
                            for (int i = 0; i < mang1chieu.Count - 4; i += 4)
                            {
                                if (mang1chieu[i] != mang1chieu[i + 1] &&
                                    mang1chieu[i] != mang1chieu[i + 2] &&
                                    mang1chieu[i] != mang1chieu[i + 3] &&
                                    mang1chieu[i + 1] != mang1chieu[i + 2] &&
                                    mang1chieu[i + 1] != mang1chieu[i + 3] &&
                                    mang1chieu[i + 2] != mang1chieu[i + 3])
                                {
                                    stop = false;
                                }
                                else
                                {
                                    error++;
                                }
                            }
                            if (error > 0) stop = true;
                        }
                        else
                        {
                            stop = false;
                        }

                    }
                    number += 6;
                    listkk.Add(mang1chieu);
                    int sothutu = 0;
                    List<string> item1 = new List<string>();
                    List<List<string>> NewOneTeam = new List<List<string>>();
                    foreach (var item in mang1chieu)
                    {
                        if (sothutu == 4)
                        {
                            NewOneTeam.Add(item1);
                            item1 = new List<string>();
                        }
                        item1.Add(item);
                        sothutu++;
                    }
                    NewList.AddRange(NewOneTeam);
                } while (OneTeam.FirstOrDefault() != null);
                DataTKB = listkk;
                return listkk;
            }
        }
        [HttpGet("getTKB")]
        public List<List<string>> GetTKB()
        {
            _teacherSubjectTeamServices.ProgressData();
            //_teacherSubjectTeamServices.ProgressData();
            //DataTKB = _teacherSubjectTeamServices.RotateMatrix(DataTKBBefore, 39, 24);
            return DataTKB;
        }

        [HttpGet("progress")]
        public string Progress()
        {
            Task.Run(() =>
            {
                ReProgress();
                _teacherSubjectTeamServices.ProgressData();
            });

            return "Ok";
        }
        [HttpGet("GetByTeacherId")]
        public async Task<List<MapTeacherSubjectTeam>> GetByTeacherId(int Id)
        {
            return await _teacherSubjectTeamServices.GetByTeacherId(Id);
        }
        [HttpGet("ReProgress")]
        public IActionResult ReProgress()
        {
            Random rnd = new Random();
            var sss = DataTKB;
            for (int i = 0; i < sss.Count; i++)
            {
                for (int j = 0; j < sss[j].Count; j++)
                {
                    var phamvi = j / 4 * 4 + 3;
                    var newMang = sss[i].Skip(phamvi).Take(4);
                    if (newMang.FirstOrDefault(x => sss[i][j] == x) != null)
                    {
                        int kq = rnd.Next(0, sss[i].Count);
                        string temp = sss[i][j];
                        sss[i][j] = sss[i][kq];
                        sss[i][kq] = temp;

                    }

                }
            }
            return Ok("OK");
        }


        [HttpGet("export-timetable")]
        public async Task ExportTimeTable()
        {

            var teams = await _teamServices.GetAllAsync();
            teams = teams.OrderBy(x => x.Name).ToList();
            var students = ThoiKhoaBieuController.DataTKB;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage("D:\\timetable.xlsx");
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            for (int i = 0; i < teams.Count;i++)
            {
                workSheet.Cells[1, i+1].Value = teams[i].Name;
                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
            }
             
            //Body of table  
            

            for(int i =0; i< students.Count; i++)
            {
                workSheet.Cells[2, i+1].LoadFromCollection(students[i]);
            }
            

            excel.Save();
             
        }
    }
} 
