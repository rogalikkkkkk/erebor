using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebErebor.Application;
using WebErebor.Models;
using BuisnessLogic.Repositories;
using BuisnessLogic.Models;
using BuisnessLogic.Services;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Text;

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
        public IActionResult GetReport(string name)
        {
            Report<Lecture> report = attendanceReportService.generateReportByStudent(name);

            Random random = new Random();
            string reportSerialize;

            if (random.Next(0, 2) == 0)
            {
                reportSerialize = JsonConvert.SerializeObject(report, Formatting.Indented);   
            }
            else
            {
                XmlSerializer xml = new XmlSerializer(typeof(Report<Lecture>));

                using (StringWriter textWriter = new StringWriter())
                {
                    xml.Serialize(textWriter, report);
                    reportSerialize = textWriter.ToString();
                }
            }
            var reportFile = new FileContentResult(Encoding.Default.GetBytes(reportSerialize), "application/octet-stream");

            reportFile.FileDownloadName = "report.txt";
            return reportFile;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}