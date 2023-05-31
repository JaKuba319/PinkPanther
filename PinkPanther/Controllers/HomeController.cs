using Microsoft.AspNetCore.Mvc;
using PinkPanther.Core;
using PinkPanther.Mappers;
using PinkPanther.Models;
using System.Diagnostics;

namespace PinkPanther.Controllers
{
    public class HomeController : Controller
    {
        readonly ViewModelMapper _mapper;
        readonly IManager _manager;

        public HomeController(IManager manager, ViewModelMapper mapper)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public IActionResult Index(string filterstring, string type, string adoptedFilter, bool adoptedOnly = false)
        {
            // is vaccinated filter
            var model = new AnimalsTypesRacesViewModel
            {
                Types = _mapper.Map(_manager.GetTypes()),
                Races = _mapper.Map(_manager.GetRaces())
            };

            switch (adoptedFilter)
            {
                case "1":
                    adoptedOnly = true;
                    model.Animals = _mapper.Map(_manager.GetAnimals(filterstring, type, adoptedOnly));
                    break;
                case "0":
                    model.Animals = _mapper.Map(_manager.GetAnimals(filterstring, type, adoptedOnly)).Where(animal => animal.Client == null);
                    break;
                default:
                    adoptedOnly = false;
                    model.Animals = _mapper.Map(_manager.GetAnimals(filterstring, type, adoptedOnly));
                    break;
            }

            

            return View(model);
        }

        public IActionResult ViewSingleAnimal(int id)
        {
            var animal = _manager.GetAnimalById(id);
            if (animal == null) return RedirectToAction("Index", "Home");
            return View(_mapper.Map(animal));
        }

        [HttpPost]
        public IActionResult Add(AnimalViewModel animalViewModel, int raceId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var race = _manager.GetRaceById(raceId);
            
            if(race == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var animalDto = _mapper.Map(animalViewModel);

            animalDto.Race = race;

            _manager.AddAnimal(animalDto);
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            _manager.DeleteAnimal(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult GoToModify(int id)
        {
            var animal = _manager.GetAnimalById(id);
            if (animal == null) return RedirectToAction("Index", "Home");

            var viewModel = new AnimalRacesViewModel()
            {
                Animal = _mapper.Map(animal),
                Races = _mapper.Map(_manager.GetRaces()),
            };

            return View("Modify", viewModel);
        }

        public IActionResult Modify(AnimalViewModel animalRacesViewModel, int raceId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var race = _manager.GetRaceById(raceId);

            if (race == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var animalDto = _mapper.Map(animalRacesViewModel);

            animalDto.Race = race;

            _manager.UpdateAnimal(animalDto);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}