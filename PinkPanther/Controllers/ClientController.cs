using Microsoft.AspNetCore.Mvc;

namespace PinkPanther.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
