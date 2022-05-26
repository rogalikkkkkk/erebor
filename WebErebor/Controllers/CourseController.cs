using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebErebor.Application;
using WebErebor.Models;
using BuisnessLogic.Repositories;
using BuisnessLogic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebErebor.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository courseRepository;
        private readonly ILectorRepository lectorRepository;

        public CourseController(ICourseRepository courseRepository, ILectorRepository lectorRepository)
        {
            this.courseRepository = courseRepository;
            this.lectorRepository = lectorRepository;
        }

        public IActionResult CourseView()
        {
            var courses = courseRepository.GetAll();
            return View(courses);
        }

        public IActionResult CourseCreate()
        {
            ViewBag.Lector = new SelectList(lectorRepository.GetAll(), "Id", "Surname");
            return View("CourseCreate", new Course());
        }

        [HttpPost]
        public IActionResult CourseCreate(Course course)
        {
            course.Lector = lectorRepository.GetById(course.Lector.Id);
            courseRepository.Save(course);

            return RedirectToAction("CourseView");
        }

        [HttpGet]
        public IActionResult CourseEdit(Course course)
        {
            ViewBag.Lector = new SelectList(lectorRepository.GetAll(), "Id", "Surname");
            return View("CourseCreate", course);
        }

        [HttpGet]
        public IActionResult CourseDelete(Course course)
        {
            courseRepository.Delete(course);
            return RedirectToAction("CourseView");
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