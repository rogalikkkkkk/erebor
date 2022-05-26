using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebErebor.Application;
using WebErebor.Models;
using BuisnessLogic.Repositories;
using BuisnessLogic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuisnessLogic.Services;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Text;

namespace WebErebor.Controllers
{
    public class LectureController : Controller
    {
        private readonly ILectureRepository lectureRepository;
        private readonly ICourseRepository courseRepository;
        private readonly AttendanceReportService attendanceReportService;

        public LectureController(ILectureRepository lectureRepository, ICourseRepository courseRepository, AttendanceReportService attendanceReportService)
        {
            this.lectureRepository = lectureRepository;
            this.courseRepository = courseRepository;
            this.attendanceReportService = attendanceReportService;
        }

        public IActionResult LectureView()
        {
            var lectures = lectureRepository.GetAll();
            return View(lectures);
        }

        public IActionResult LectureCreate()
        {
            ViewBag.Course = new SelectList(courseRepository.GetAll(), "Id", "Title");

            return View("LectureCreate", new Lecture());
        }

        [HttpPost]
        public IActionResult LectureCreate(Lecture lecture)
        {
            lecture.Course = courseRepository.GetById(lecture.Course.Id);
            lectureRepository.Save(lecture);
            return RedirectToAction("LectureView");
        }

        [HttpGet]
        public IActionResult LectureEdit(int id)
        {
            ViewBag.Course = new SelectList(courseRepository.GetAll(), "Id", "Title");
            return View("LectureCreate", lectureRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult GetReport(string title)
        {
            Report<Student> report = attendanceReportService.generateReportByLecture(title);

            Random random = new Random();
            string reportSerialize;

            if (random.Next(0, 2) == 0)
            {
                reportSerialize = JsonConvert.SerializeObject(report, Formatting.Indented);
            }
            else
            {
                XmlSerializer xml = new XmlSerializer(typeof(Report<Student>));

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

        [HttpGet]
        public IActionResult LectureDelete(Lecture lecture)
        {
            lectureRepository.Delete(lecture);
            return RedirectToAction("LectureView");
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