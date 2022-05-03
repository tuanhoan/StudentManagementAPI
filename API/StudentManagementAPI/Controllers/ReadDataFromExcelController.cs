//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using StudentManagementAPI.Services;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using static StudentManagementAPI.Services.ReadDataFromExcelService;

//namespace StudentManagementAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ReadDataFromExcelController : ControllerBase
//    {
//        private readonly ReadDataFromExcelService _readDataFromExcelService;
//        public ReadDataFromExcelController(ReadDataFromExcelService readDataFromExcelService)
//        {
//            _readDataFromExcelService = readDataFromExcelService;
//        }

//        [HttpGet]
//        public List<DuLieu> GetAll()
//        {
//            return _readDataFromExcelService.ReadData();
//        }
//        [HttpGet("AddData")]
//        public async Task<IActionResult> AddData()
//        {
//            await _readDataFromExcelService.AddData();
//            return Ok();
//        }
//        [HttpGet("AddTKB")]
//        public async Task<IActionResult> AddTKB()
//        {
//            await _readDataFromExcelService.AddTKB();
//            return Ok();
//        }
//    }
//}
