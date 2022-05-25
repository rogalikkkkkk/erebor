using BuisnessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Observer
{
    public interface IAttendanceSubscriber
    {
        public void NotifyBySms(Student student, Course course);
        public void NotifyByEmail(Student student, Lector lector, Course course);
    }
}
