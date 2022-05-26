using BuisnessLogic.Models;
using BuisnessLogic.Repositories;
using Microsoft.EntityFrameworkCore;
using WebErebor.Application;

namespace WebErebor.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _db;

    public StudentRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public List<Student> GetAll()
    {
        return _db.Students.ToList();
    }

    public Student GetById(int id)
    {
        var student = _db.Students.FirstOrDefault(s => s.Id == id);
        if (student == null) throw new Exception("По данному ID не было найдено записей в таблице студентов");

        return student;
    }

    public Student Save(Student entity)
    {
        var student = _db.Update(entity);
        _db.SaveChanges();
        return student.Entity;
    }

    public void Delete(Student entity)
    {
        if (!_db.Students.Contains(entity)) return;
        _db.Remove(entity);
        _db.SaveChanges();
    }

    public Student getByName(string name)
    {
        var student = _db.Students.FirstOrDefault(s => s.Name == name);
        if (student == null) throw new Exception("По данному имени не было найдено записей в таблице студентов");
        return student;
    }
}