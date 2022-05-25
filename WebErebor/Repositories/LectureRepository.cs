using BuisnessLogic.Models;
using BuisnessLogic.Repositories;
using WebErebor.Application;

namespace WebErebor.Repositories;

public class LectureRepository : ILectureRepository
{
    private readonly ApplicationDBContext _db;

    public LectureRepository(ApplicationDBContext db)
    {
        _db = db;
    }
    public List<Lecture> GetAll()
    {
        var lecturesList = _db.Lectures.ToList();
        foreach (var lecture in lecturesList)
        {
            lecture.Course = null;
        }

        return lecturesList;
    }

    public Lecture GetById(int id)
    {
        var lecture = _db.Lectures.FirstOrDefault(l => l.Id == id);
        if (lecture == null)
        {
            throw new Exception("По данному ID не было найдено записей в таблице лекций");
        }

        lecture.Course = null;
        return lecture;
    }

    public Lecture Save(Lecture entity)
    {
        var lecture = _db.Update(entity);
        _db.SaveChanges();
        return lecture.Entity;
    }

    public void Delete(Lecture entity)
    {
        if (!_db.Lectures.Contains(entity)) return;
        _db.Remove(entity);
        _db.SaveChanges();
    }

    public Lecture getByTitle(string title)
    {
        var lecture = _db.Lectures.FirstOrDefault(l => l.Title == title);
        if (lecture == null)
        {
            throw new Exception("По данному названию не было найдено записей в таблице лекций");
        }

        lecture.Course = null;
        return lecture;
    }
}