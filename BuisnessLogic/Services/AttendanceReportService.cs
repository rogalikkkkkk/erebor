using Erebor.Models;
using Erebor.Repositories;

namespace Erebor.Services
{
    public class AttendanceReportService
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
            var attendances = attendanceRepository.getAllByLecture(lecture.Id);
            var report = from a in attendances
                         select new ReportEntity<Student> { Entity = a.Student!, Attanded = a.Attended, Grade = a.Grade };

            return new Report<Student> { Data = report.ToList() };
        }

        public Report<Lecture> generateReportByStudent(string name)
        {
            var student = studentRepository.getByName(name);
            var attendances = attendanceRepository.getAllByStudent(student.Id);

            var report = from a in attendances
                         select new ReportEntity<Lecture> { Entity = a.Lecture!, Attanded = a.Attended, Grade = a.Grade };

            return new Report<Lecture> { Data = report.ToList()};
        }
    }
}
