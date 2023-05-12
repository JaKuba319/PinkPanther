using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;
using System.Security.Cryptography.Xml;

namespace PinkPanther.Controllers
{
    public class RaceController : Controller
    {
        private readonly List<RaceViewModel> _races = TestDatabaseTODELETE.RACES;

        private int _index;
        public IActionResult Index()
        {
            return View(_races);
        }
        public IActionResult Modify(int index)
        {
            var race = _races.Where(race => race.Index == index).First();
            _index = index;
            return View(race);
        }

        public IActionResult ChangeType(string race)
        {
            //send changes to database
            var racevm = new RaceViewModel() { Index = _index, Race = race };

            TestDatabaseTODELETE.RACES[_index] = racevm;


            return RedirectToAction("Index", "Race");
        }
    }
}
