using BuisnessLogic.Models;
using BuisnessLogic.Repositories;
using Microsoft.EntityFrameworkCore;
using WebErebor.Application;

namespace WebErebor.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly ApplicationDBContext _db;

    public AttendanceRepository(ApplicationDBContext db)
    {
        _db = db;
    }

    public List<Attendance> GetAll()
    {
        return _db.Attendances.ToList();
    }

    public Attendance GetById(int id)
    {
        var attendance = _db.Attendances.FirstOrDefault(a => a.Id == id);
        if (attendance == null)
        {
            throw new Exception("По данному ID не было найдено записей в таблице посещений");
        }

        return attendance;
    }

    public Attendance Save(Attendance entity)
    {
        var attendance = _db.Update(entity);
        _db.SaveChanges();
        return attendance.Entity;
    }

    public void Delete(Attendance entity)
    {
        if (!_db.Attendances.Contains(entity)) return;
        _db.Remove(entity);
        _db.SaveChanges();
    }

    public List<Attendance> getAllByStudent(Student student)
    {
        return _db.Attendances.Where(a => a.Student.Id == student.Id).ToList();
    }

    public List<Attendance> getAllByLecture(Lecture lecture)
    {
        return _db.Attendances.Where(a => a.Lecture.Id == lecture.Id).ToList();
    }
}