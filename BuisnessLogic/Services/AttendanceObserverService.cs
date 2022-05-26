using Erebor.Models;
using Erebor.Repositories;

namespace Erebor.Observer
{
    public class AttendanceObserverService
    {
        private readonly IAttendanceRepository attendanceRepository;
        private readonly List<IAttendanceObserver> attendanceObservers;

        public AttendanceObserverService(
            IAttendanceRepository attendanceRepository,
            List<IAttendanceObserver> attendanceObservers)
        {
            this.attendanceRepository = attendanceRepository;
            this.attendanceObservers = attendanceObservers;
        }

        public void onAttendance(Attendance attendance)
        {
            var courseAttendance = attendanceRepository
                .getAllByStudent(attendance.StudentId)
                .GroupBy(att => att.Lecture!.Course);

            foreach (var course in courseAttendance)
            {
                foreach (var observer in attendanceObservers)
                {
                    if (observer.IsNeedNotify(course.ToList()))
                    {
                        observer.Notify(attendance);
                    }
                }             
            }
        }
    }
}
