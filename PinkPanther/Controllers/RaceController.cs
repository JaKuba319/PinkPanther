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
            var races = _mapper.Map(_manager.GetRaces());
            var types = _mapper.Map(_manager.GetTypes());

            var model = new TypeRaceViewModel() { Races = races, Types = types };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(RaceViewModel raceViewModel, int typeId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var typeDto = _manager.GetTypeById(typeId);

            if(typeDto == null) return RedirectToAction("Index");

            var raceDto = _mapper.Map(raceViewModel);
            raceDto.Type = typeDto;

            _manager.AddRace(raceDto);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _manager.DeleteRace(id);

            return RedirectToAction("Index");
        }

        public IActionResult GoToModify(int id)
        {
            var race = _manager.GetRaces().Where(race => race.Id == id).FirstOrDefault();

            if (race == null)
            {
                return RedirectToAction("Index");
            }

            var raceViewModel = _mapper.Map(race);

            return View("Modify", raceViewModel);
        }

        public IActionResult Modify(RaceViewModel raceViewModel, int typeId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var typeDto = _manager.GetTypeById(typeId);

            if (typeDto == null) return RedirectToAction("Index");


            var raceDto = _mapper.Map(raceViewModel);
            raceDto.Type = typeDto;

            _manager.UpdateRace(raceDto);
            
            return RedirectToAction("Index", "Race");
        }

        
    }
}
