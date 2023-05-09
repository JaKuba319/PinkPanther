using Microsoft.AspNetCore.Mvc;

namespace PinkPanther.Controllers
{
    public class AnimalController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
