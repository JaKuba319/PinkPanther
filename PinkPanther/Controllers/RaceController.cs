using Microsoft.AspNetCore.Mvc;
using PinkPanther.Core;
using PinkPanther.Mappers;
using PinkPanther.Models;

namespace PinkPanther.Controllers
{
    public class RaceController : Controller
    {
        readonly ViewModelMapper _mapper;
        readonly IManager _manager;
        public RaceController(IManager manager, ViewModelMapper mapper)
        {
            _mapper = mapper;
            _manager = manager;
        }
        public IActionResult Index()
        {
            var races = _manager.GetRaces();

            return View(_mapper.Map(races));
        }

        //[HttpPost]
        public IActionResult Add(string race)
        {
            _manager.AddRace(new RaceDto() { RaceName = race });
            return RedirectToAction("Index", "Race");
        }

        //[HttpDelete]
        public IActionResult Delete(int id)
        {
            _manager.DeleteRace(id);

            return RedirectToAction("Index", "Race");
        }

        public IActionResult Modify(int id)
        {
            var races = _manager.GetRaces();
            var race = races.Where(race => race.Id == id).FirstOrDefault();
            if (race != null)
            {
                return View(_mapper.Map(race));
            }
            return RedirectToAction("Index", "Race");
        }

        //[HttpPut]
        public IActionResult Change(int id, string race)
        {
            if (!string.IsNullOrEmpty(race))
            {
                var racevm = new RaceViewModel() { Id = id, RaceName = race };

                _manager.UpdateRace(_mapper.Map(racevm));
            }

            return RedirectToAction("Index", "Race");
        }

        
    }
}
