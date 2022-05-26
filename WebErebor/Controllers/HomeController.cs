using Microsoft.AspNetCore.Mvc;
using BuisnessLogic.Repositories;
using BuisnessLogic.Models;
using BuisnessLogic.Services;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Text;
using WebErebor.Serializers;

namespace WebErebor.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly AttendanceReportService attendanceReportService;

        public HomeController(IStudentRepository studentRepository, AttendanceReportService attendanceReportService)
        {
            this.studentRepository = studentRepository;
            this.attendanceReportService = attendanceReportService;
        }

        public IActionResult Index()
        {
            var students = studentRepository.GetAll();
            return View(students);
        }

        public IActionResult StudentCreate()
        {
            Student student = new Student();

            return View("StudentCreate", student);
        }

        [HttpPost]
        public IActionResult StudentCreate(Student student)
        {
            studentRepository.Save(student);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult StudentEdit(Student student)
        {
            return View("StudentCreate", student);
        }

        [HttpGet]
        public IActionResult StudentDelete(Student student)
        {
            studentRepository.Delete(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetReport(string name, Format format)
        {
            Report<Lecture> report = attendanceReportService.generateReportByStudent(name);
            var serializer = SerializerFactory.GetSerializer<Lecture>(format);
            byte[] reportSerialized = serializer.Serialize(report.Data);

            return new FileContentResult(reportSerialized, "application/octet-stream")
            {
                FileDownloadName = serializer.FileName("report")
            };
        }
    }
}