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
            var race = _races.Where(race => race.Index == index).FirstOrDefault();
            if (race != null)
            {
                _index = index;
                return View(race);
            }
            return RedirectToAction("Index", "Race");
        }

        public IActionResult ChangeType(string race)
        {
            //send changes to database
            var racevm = new RaceViewModel() { Index = _index, Race = race };

            TestDatabaseTODELETE.RACES[_index] = racevm;


            return RedirectToAction("Index", "Race");
        }

        public IActionResult Delete(int index)
        {
            var toDelete = TestDatabaseTODELETE.RACES.Where(race => race.Index == index).FirstOrDefault();
            if (toDelete == null) return RedirectToAction("Index", "Race");
            TestDatabaseTODELETE.RACES.Remove(toDelete);
            return RedirectToAction("Index", "Race");
        }
    }
}
