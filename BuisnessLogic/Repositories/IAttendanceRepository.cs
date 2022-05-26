using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLogic.Models;

namespace BuisnessLogic.Repositories
{
    public interface IAttendanceRepository : CrudRepository<Attendance>
    {
        public List<Attendance> getAllByStudent(int studentId);
        public List<Attendance> getAllByLecture(int lectureId);
    }
}
