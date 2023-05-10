using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;

namespace PinkPanther.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index(int index)
        {
            var animal = TestDatabaseTODELETE.ANIMALS.Where(animal => animal.Index == index).First();
            return View(animal);
        }
        public IActionResult Adopt(int index)
        {
            return RedirectToAction("Index", "Adoption", new { index }); // to change
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
