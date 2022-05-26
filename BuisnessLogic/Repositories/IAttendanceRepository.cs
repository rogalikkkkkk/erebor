using Erebor.Models;

namespace Erebor.Repositories
{
    public interface IAttendanceRepository : CrudRepository<Attendance>
    {
        public List<Attendance> getAllByStudent(int studentId);
        public List<Attendance> getAllByLecture(int lectureId);
    }
}
