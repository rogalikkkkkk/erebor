using BuisnessLogic.Models;
using BuisnessLogic.Repositories;
using WebErebor.Application;

namespace WebErebor.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _db;


    public CourseRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public List<Course> GetAll()
    {
        return _db.Courses.ToList();
    }

    public Course GetById(int id)
    {
        var course = _db.Courses.FirstOrDefault(c => c.Id == id);
        if (course == null) throw new Exception("По данному ID не было найдено записей в таблице курсов");

        return course;
    }

    public Course Save(Course entity)
    {
        var course = _db.Update(entity);
        _db.SaveChanges();
        return course.Entity;
    }

    public void Delete(Course entity)
    {
        if (!_db.Courses.Contains(entity)) return;
        _db.Remove(entity);
        _db.SaveChanges();
    }
}