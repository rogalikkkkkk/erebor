using BuisnessLogic.Models;
using BuisnessLogic.Repositories;
using Erebor.Application;
using Erebor.Repositories;

namespace Erebor
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