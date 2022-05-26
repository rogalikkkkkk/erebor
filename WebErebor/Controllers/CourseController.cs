using Microsoft.AspNetCore.Mvc;
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
            course.Lector = lectorRepository.GetById(course.LectorId);
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
    }
}