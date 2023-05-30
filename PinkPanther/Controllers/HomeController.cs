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
        public IActionResult Add(string name, string description, int raceId, string gender, string isVaccinated, string birthDate)
        {
            // add validation 
            var race = _manager.GetRaceById(raceId);
            
            if(race == null || !DateOnly.TryParse(birthDate, out var date))
            {
                //error
                return RedirectToAction("Index", "Home");
            }

            var animal = new AnimalDto()
            { 
                Name = name,
                Description = description,
                Race = race,
                BirthDate = date,
                Gender = gender == "1",
                IsVaccinated = isVaccinated == "1"
            };

            _manager.AddAnimal(animal);
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            _manager.DeleteAnimal(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Modify(int id)
        {
            var animal = _manager.GetAnimalById(id);
            if (animal == null) return RedirectToAction("Index", "Home");

            var viewModel = new AnimalModifyViewModel()
            {
                Animal = _mapper.Map(animal),
                //Types = _mapper.Map(_manager.GetTypes()),
                Races = _mapper.Map(_manager.GetRaces()),
            };

            return View(viewModel);
        }

        public IActionResult Change(int id, string name, string gender, string birthDate, int raceId, string isVaccinated, string description)
        {
            // add validation 
            var race = _manager.GetRaceById(raceId);

            if (race == null || !DateOnly.TryParse(birthDate, out var date))
            {
                //error
                return RedirectToAction("Index", "Home");
            }

            var oldAnimal = _manager.GetAnimalById(id);
            if (oldAnimal == null) return RedirectToAction("Index", "Home");

            var animal = new AnimalViewModel()
            {
                Id = id,
                BirthDate = DateOnly.Parse(birthDate),
                Name = name,
                Gender = gender == "1",
                IsVaccinated = isVaccinated == "1",
                Description = description,
                Race = _mapper.Map(_manager.GetRaceById(raceId)),
                //Type = _mapper.Map(_manager.GetTypeById(typeId)),
                Client = _mapper.Map(oldAnimal.Client)
            };

            _manager.UpdateAnimal(_mapper.Map(animal));

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