using Microsoft.AspNetCore.Mvc;

namespace PinkPanther.Controllers
{
    public class RaceController : Controller
    {
        private readonly List<string> _races = TestDatabaseTODELETE.ANIMALS.Select(x => x.Race).Distinct().ToList();
        public IActionResult Index()
        {
            return View(_races);
        }
    }
}
