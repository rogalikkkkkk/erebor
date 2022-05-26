using BuisnessLogic.Models;

namespace BuisnessLogic.Observer
{
    public abstract class EmailAttendanceObserver : IAttendanceObserver
    {
        public override bool IsNeedNotify(List<Attendance> attendances)
        {
            return attendances.Where(att => !att.Attended).Count() > 3;
        }

        public override void Notify(Attendance attendance)
        {
            Execute
            (
                attendance.Student!.Email,
                $"Вы пропустили более 3 лекций на курсе {attendance.Lecture!.Course!.Title}"
            );

            Execute
            (
                attendance.Lecture!.Course!.Lector!.Email,
                $"Студент {attendance.Student!.Name} {attendance.Student!.Surname} пропустил более 3 лекций на курсе {attendance.Lecture!.Course!.Title}"
            );
        }
    }
}
