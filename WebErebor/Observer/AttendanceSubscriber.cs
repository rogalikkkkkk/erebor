

using BuisnessLogic.Models;
using BuisnessLogic.Observer;

namespace WebErebor.Observer
{
    public class AttendanceSubscriber : IAttendanceSubscriber
    {
        public void NotifyByEmail(Student student, Lector lector, Course course)
        {
            return;
        }

        public void NotifyBySms(Student student, Course course)
        {
            return;
        }
    }
}
