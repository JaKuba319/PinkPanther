using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;
using System.Diagnostics;

namespace PinkPanther.Controllers
{
    public class HomeController : Controller
    {
        // List of animals available to adopt
        private readonly List<AnimalViewModel> _animals = TestDatabaseTODELETE.ANIMALS;

        public IActionResult Index(string filterstring, string type, bool adoptedOnly = false)
        {
            var model = new AnimalsAndTypesViewModel();
            var animals = _animals;
            if(string.IsNullOrEmpty(filterstring) && string.IsNullOrEmpty(type))
            {
                model.Animals = animals.Where(animal => animal.IsAdopted == adoptedOnly || !adoptedOnly);
                model.Types = _animals.Select(animal => animal.Type).Distinct();

                return View(model);
            }

            if(string.IsNullOrEmpty(filterstring))
            {
                animals = animals.Where(animal => animal.Type == type).ToList(); 
            }
            else if (string.IsNullOrEmpty(type))
            {
                filterstring = filterstring.Trim().ToLower();
                animals = animals.Where(animal => animal.Name.ToLower().Contains(filterstring) ).ToList();
            }
            else
            {
                filterstring = filterstring.Trim().ToLower();
                animals = animals.Where(animal => animal.Type == type).ToList();
                animals = animals.Where(animal => animal.Name.ToLower().Contains(filterstring)).ToList();
            }

            model.Animals = animals;
            model.Types = _animals.Select(animal => animal.Type).Distinct();

            return View(model);
        }

        public IActionResult ViewSingleAnimal(int indexOfAnimal)
        {
            return RedirectToAction("Index", "Animal", new { index = indexOfAnimal });
        }

        public IActionResult Add(string animalName, string race, string type, string animalGender, string animalBirthDate)
        {
            // add validation 

            var animal = new AnimalViewModel()
            { 
                Index = TestDatabaseTODELETE.ANIMALS.Last().Index + 1,
                Name = animalName,
                Race = race,
                Type = type,
                BirthDate = DateOnly.Parse(animalBirthDate),
                Sex = animalGender == "1"
            };

            TestDatabaseTODELETE.ANIMALS.Add(animal);
            
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