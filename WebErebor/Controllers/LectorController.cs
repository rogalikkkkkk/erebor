using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
            return View("LectorCreate", new Lector());
        }

        [HttpPost]
        public IActionResult LectorCreate(Lector lector)
        {
            lectorRepository.Save(lector);

            return RedirectToAction("LectorView");
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
    }
}