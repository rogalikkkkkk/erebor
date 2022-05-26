using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebErebor.Application;
using WebErebor.Models;
using BuisnessLogic.Repositories;
using BuisnessLogic.Models;

namespace WebErebor.Controllers
{
    public class LectorController : Controller
    {
        private readonly ILectorRepository lectorRepository;

        public LectorController(ILectorRepository lectorRepository)
        {
            this.lectorRepository = lectorRepository;
        }

        public IActionResult LectorView()
        {
            var lectors = lectorRepository.GetAll();
            return View(lectors);
        }

        public IActionResult LectorCreate()
        {            
            return View("StudentCreate", new Lector());
        }

        [HttpPost]
        public IActionResult StudentCreate(Lector lector)
        {
            lectorRepository.Save(lector);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult LectorEdit(Lector lector)
        {
            return View("LectorCreate", lector);
        }

        [HttpGet]
        public IActionResult LectorDelete(Lector lector)
        {
            lectorRepository.Delete(lector);
            return RedirectToAction("LectorView");
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