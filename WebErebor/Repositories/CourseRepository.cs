using BuisnessLogic.Models;
using BuisnessLogic.Repositories;
using WebErebor.Application;

namespace WebErebor.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDBContext _db;


    public CourseRepository(ApplicationDBContext db)
    {
        _db = db;
    }

    public List<Course> GetAll()
    {
        return _db.Cources.ToList();
    }

    public Course GetById(int id)
    {
        var course = _db.Cources.FirstOrDefault(c => c.Id == id);
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
        if (!_db.Cources.Contains(entity)) return;
        _db.Remove(entity);
        _db.SaveChanges();
    }
}