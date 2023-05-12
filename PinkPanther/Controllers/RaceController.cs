using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;
using System.Security.Cryptography.Xml;

namespace PinkPanther.Controllers
{
    public class RaceController : Controller
    {
        private readonly List<RaceViewModel> _races = TestDatabaseTODELETE.RACES;

        public IActionResult Index()
        {
            return View(_races);
        }
        public IActionResult Modify(int index)
        {
            var race = _races.Where(race => race.Index == index).FirstOrDefault();
            if (race != null)
            {
                return View(race);
            }
            return RedirectToAction("Index", "Race");
        }

        public IActionResult ChangeType(int index, string race)
        {
            //send changes to database
            if (!string.IsNullOrEmpty(race))
            {
                var racevm = new RaceViewModel() { Index = index, Race = race };

                TestDatabaseTODELETE.RACES[index] = racevm;
            }

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
