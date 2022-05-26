using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BuisnessLogic.Repositories;
using BuisnessLogic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuisnessLogic.Services;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Text;
using WebErebor.Serializers;
using BuisnessLogic.Observer;

namespace WebErebor.Controllers
{
    public class LectureController : Controller
    {
        private readonly ILectureRepository lectureRepository;
        private readonly ICourseRepository courseRepository;
        private readonly IAttendanceRepository attendanceRepository;
        private readonly IStudentRepository studentRepository;
        private readonly AttendanceReportService attendanceReportService;
        private readonly AttendanceObserverService attendanceObserverService;

        public LectureController(
            ILectureRepository lectureRepository,
            ICourseRepository courseRepository,
            AttendanceReportService attendanceReportService,
            IAttendanceRepository attendanceRepository,
            IStudentRepository studentRepository,
            AttendanceObserverService attendanceObserverService
            )
        {
            this.lectureRepository = lectureRepository;
            this.courseRepository = courseRepository;
            this.attendanceReportService = attendanceReportService;
            this.attendanceRepository = attendanceRepository;
            this.studentRepository = studentRepository;
            this.attendanceObserverService = attendanceObserverService;
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
            lectureRepository.Save(lecture);
            return RedirectToAction("LectureView");
        }

        [HttpGet]
        public IActionResult LectureEdit(int id)
        {
            var lecture = lectureRepository.GetById(id);
            ViewBag.Course = new SelectList(courseRepository.GetAll(), "Id", "Title");
            return View("LectureCreate", lecture);
        }

        [HttpGet]
        public IActionResult GetReport(string title, Format format)
        {
            Report<Student> report = attendanceReportService.generateReportByLecture(title);
            var serializer = SerializerFactory.GetSerializer<Student>(format);
            byte[] reportSerialized = serializer.Serialize(report.Data);

            return new FileContentResult(reportSerialized, "application/octet-stream")
            {
                FileDownloadName = serializer.FileName("report")
            };
        }

        [HttpGet]
        public IActionResult LectureDelete(Lecture lecture)
        {
            lectureRepository.Delete(lecture);
            return RedirectToAction("LectureView");
        }

        [HttpGet]
        public IActionResult LectureAttendance(Lecture lecture)
        {
            var students = studentRepository.GetAll();
            var attendances = attendanceRepository.getAllByLecture(lecture.Id);

            if (students.Count == attendances.Count) return View("LectureAttendance", attendances);
            foreach (var student in students)
            {
                if (attendances.FirstOrDefault(a => a.StudentId == student.Id) != null) continue;

                var attendance = new Attendance
                {
                    StudentId = student.Id,
                    Student = student,
                    LectureId = lecture.Id
                };

                attendances.Add(attendance);
            }

            return View("LectureAttendance", attendances);
        }

        [HttpPost]
        public IActionResult AttendanceCreate(List<Attendance> attList)
        {
            foreach (var att in attList)
            {
                attendanceRepository.Save(att);
                attendanceObserverService.onAttendance(att);
            }
            return RedirectToAction("LectureView");
        }
    }
}