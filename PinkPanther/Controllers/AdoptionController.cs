using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PinkPanther.Controllers
{
    public class AdoptionController : Controller
    {
        public IActionResult Index(int index)
        {
            return View(TestDatabaseTODELETE.ANIMALS.Where(animal => animal.Index == index).First());
        }
    }
}
