using BuisnessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace WebErebor.Application;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var stud1 = new Student { Id = 1, Name = "Ilia", Surname = "Rodionov", Age = 20, Email = "ilia@gmail.com", PhoneNumber = "89133466584"};
        var stud2 = new Student { Id = 2, Name = "Daria", Surname = "Lisina", Age = 20, Email = "lisina@gmail.com", PhoneNumber = "89313466584"};
        var lector = new Lector { Id = 1, Name = "Anatoliy", Email = "sergeev@gmai.com", Salary = 1000, Surname = "Sergeev" };
        var course = new Course { Id = 1, Title = "Web Programming", LectorId = 1 };
        var lecture1 = new Lecture { Id = 1, Title = "Introduction", Date = new DateTime(2022, 2, 2, 10, 0, 0), CourseId = 1};
        var lecture2 = new Lecture { Id = 2, Title = "Asp .Net", Date = new DateTime(2022, 2, 9, 10, 0, 0), CourseId = 1};

        modelBuilder.Entity<Student>().HasData(stud1, stud2);
        modelBuilder.Entity<Lector>().HasData(lector);
        modelBuilder.Entity<Course>().HasData(course);
        modelBuilder.Entity<Lecture>().HasData(lecture1, lecture2);
    }
}