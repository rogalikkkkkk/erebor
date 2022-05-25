using BuisnessLogic.Models;
using BuisnessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Observer
{
    public class AttendanceObserverService
    {
        private IAttendanceRepository attendanceRepository;
        private IAttendanceSubscriber attendanceSubscriber;

        public AttendanceObserverService(IAttendanceRepository repository, IAttendanceSubscriber subscriber)
        {
            attendanceRepository = repository;
            attendanceSubscriber = subscriber;
        }

        public void onAttendance(Attendance attendance)
        {
            var courseAttendance = attendanceRepository.getAllByStudent(attendance.Student).GroupBy(att => att.Lecture.Course);
            foreach (var course in courseAttendance)
            {
                if (checkAvgGrade(course.ToList())) {
                    attendanceSubscriber.NotifyBySms(attendance.Student, attendance.Lecture.Course);
                }
                if (checkSkips(course.ToList())) {
                    attendanceSubscriber.NotifyByEmail(attendance.Student, 
                        attendance.Lecture.Course.Lector, 
                        attendance.Lecture.Course);
                }
            }

        }

        private bool checkAvgGrade(List<Attendance> attendances)
        {
            return attendances.Average(att => att.Grade) > 4;
        }

        private bool checkSkips(List<Attendance> attendances)
        {
            return attendances.Select(att => att.Attended).Count() < 3;
        }
    }
}
