using Microsoft.AspNetCore.Mvc;

namespace PinkPanther.Controllers
{
    public class AdoptionController : Controller
    {
        public IActionResult Index(int index)
        {
            return View(index);
        }
    }
}
