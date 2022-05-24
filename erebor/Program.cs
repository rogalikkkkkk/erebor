using BuisnessLogic.Models;
using BuisnessLogic.Repositories;
using WebErebor.Application;
using WebErebor.Repositories;

namespace WebErebor
{
    internal class Programm
    {
        static void Main(string[] args)
        {
            ApplicationDBContext db = new ApplicationDBContext();
            
            StudentRepository sr = new StudentRepository();
            sr.Save(db.Students.ToList()[0]);
        }
    }
}