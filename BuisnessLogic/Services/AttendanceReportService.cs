using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLogic.Models;
using BuisnessLogic.Repositories;

namespace BuisnessLogic.Services
{
    internal class AttendanceReportService
    {
        private readonly IAttendanceRepository attendanceRepository;
        private readonly ILectureRepository lectureRepository;
        private readonly IStudentRepository studentRepository;

        public AttendanceReportService(IAttendanceRepository attendanceRepository, ILectureRepository lectureRepository, IStudentRepository studentRepository)
        {
            this.attendanceRepository = attendanceRepository;
            this.lectureRepository = lectureRepository;
            this.studentRepository = studentRepository;
        }
        
        public Report<Student> generateReportByLecture(string title)
        {
            var lecture = lectureRepository.getByTitle(title);
            var attendances = attendanceRepository.getAllByLecture(lecture);
            var report = from a in attendances
                         select new ReportEntity<Student> { Entity = a.Student, Attanded = a.Attended, Grade = a.Grade };
            Report<Student> result = new Report<Student>();
            foreach (var r in report)
            {
                result.Data.Add(r);
            }

            return result;
        }

        public Report<Lecture> generateReportByStudent(string name)
        {
            var student = studentRepository.getByName(name);
            var attendances = attendanceRepository.getAllByStudent(student);

            var report = from a in attendances
                         select new ReportEntity<Lecture> { Entity = a.Lecture, Attanded = a.Attended, Grade = a.Grade };
            Report<Lecture> result = new Report<Lecture>();
            foreach (var r in report)
            {
                result.Data.Add(r);
            }

            return result;
        }
    }
}
