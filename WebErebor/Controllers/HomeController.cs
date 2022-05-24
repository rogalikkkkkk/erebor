using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebErebor.Application;
using WebErebor.Models;
using BuisnessLogic.Repositories;
using BuisnessLogic.Models;

namespace WebErebor.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository studentRepository;

        public HomeController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            var students = studentRepository.GetAll();
            return View(students);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}