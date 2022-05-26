using BuisnessLogic.Models;

namespace BuisnessLogic.Observer
{
    public abstract class SmsAttendanceObserver : IAttendanceObserver
    {
        public override bool IsNeedNotify(List<Attendance> attendances)
        {
            return attendances.Average(att => att.Grade) < 4;
        }

        public override void Notify(Attendance attendance)
        {
            Execute(attendance.Student!.PhoneNumber,
                $"Ваш средний балл по курсу {attendance.Lecture!.Course!.Title} ниже 4х баллов"
            );
        }
    }
}
