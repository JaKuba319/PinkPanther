using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;

namespace PinkPanther.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index(int index)
        {
            var animal = TestDatabaseTODELETE.ANIMALS.Where(animal => animal.Index == index).FirstOrDefault();
            if (animal == null) return RedirectToAction("Index", "Home");
            return View(animal);
        }

        /*
        // idk if i should use it like that
        public IActionResult Adopt(int index)
        {
            return RedirectToAction("Index", "Adoption", new { index }); // to change
        }
        */
        public IActionResult Delete(int index)
        {
            var toDelete = TestDatabaseTODELETE.ANIMALS.Where(animal => animal.Index == index).FirstOrDefault();
            if(toDelete == null) return RedirectToAction("Index", "Home");
            TestDatabaseTODELETE.ANIMALS.Remove(toDelete);
            return RedirectToAction("Index", "Home");
        }
    }
}
