using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;

namespace PinkPanther.Controllers
{
    public class AnimalController : Controller
    {
        
        public IActionResult Index(int index)
        {
            var animal = TestDatabaseTODELETE.ANIMALS.ElementAt(index);
            return View(animal);
        }
    }
}
