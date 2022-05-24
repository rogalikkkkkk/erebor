//using BuisnessLogic.Models;
//using BuisnessLogic.Repositories;
//using Erebor.Application;

//namespace Erebor.Repositories;

//public class AttendanceRepository : IAttendanceRepository
//{
//    private readonly ApplicationDBContext _db = new();

//    public List<Attendance> GetAll()
//    {
//        var attendanceList = _db.Attendances.ToList();
//        foreach (var attendance in attendanceList)
//        {
//            attendance.Lecture = null;
//            attendance.Student = null;
//        }

//        return attendanceList;
//    }

//    public Attendance GetById(int id)
//    {
//        var attendance = _db.Attendances.FirstOrDefault(a => a.Id == id);
//        if (attendance == null)
//        {
//            throw new Exception("По данному ID не было найдено записей в таблице посещений");
//        }

//        attendance.Lecture = null;
//        attendance.Student = null;
//        return attendance;
//    }

//    public Attendance Save(Attendance entity)
//    {
//        var attendance = _db.Update(entity);
//        _db.SaveChanges();
//        return attendance.Entity;
//    }

//    public void Delete(Attendance entity)
//    {
//        if (!_db.Attendances.Contains(entity)) return;
//        _db.Remove(entity);
//        _db.SaveChanges();
//    }

//    public List<Attendance> getAllByStudent(Student student)
//    {
//        var attendanceList = _db.Attendances.Where(a => a.Student.Id == student.Id).ToList();
//        foreach (var attendance in attendanceList)
//        {
//            attendance.Lecture = null;
//            attendance.Student = null;
//        }

//        return attendanceList;
//    }

//    public List<Attendance> getAllByLecture(Lecture lecture)
//    {
//        var attendanceList = _db.Attendances.Where(a => a.Lecture.Id == lecture.Id).ToList();
//        foreach (var attendance in attendanceList)
//        {
//            attendance.Lecture = null;
//            attendance.Student = null;
//        }

//        return attendanceList;
//    }
//}