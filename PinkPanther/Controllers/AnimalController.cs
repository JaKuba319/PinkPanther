using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

namespace PinkPanther.Controllers
{
    public class AnimalController : Controller
    {

        public IActionResult Index(int index)
        {
            var animal = TestDatabaseTODELETE.ANIMALS.Where(animal => animal.Index == index).FirstOrDefault();
            if (animal == null) return RedirectToAction("Index", "Home");
            return View(animal);
        }

        /*
        // idk if i should use it like that
        public IActionResult Adopt(int index)
        {
            return RedirectToAction("Index", "Adoption", new { index }); // to change
        }
        */
        public IActionResult Delete(int index)
        {
            var animal = TestDatabaseTODELETE.ANIMALS.Where(animal => animal.Index == index).FirstOrDefault();
            if (animal == null) return RedirectToAction("Index", "Home");
            TestDatabaseTODELETE.ANIMALS.Remove(animal);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Modify(int index)
        {
            var animal = TestDatabaseTODELETE.ANIMALS.Where(animal => animal.Index == index).FirstOrDefault();
            if (animal == null) return RedirectToAction("Index", "Home");
            return View(animal);
        }

        public IActionResult Change(int index, string name, string gender, string birthDate, string race, string type, string adopted)
        {
            // add validation 
            var oldAnimal = TestDatabaseTODELETE.ANIMALS.Where(animal => animal.Index == index).FirstOrDefault();
            if (oldAnimal == null) return RedirectToAction("Index", "Home");

            var animal = new AnimalViewModel()
            {
                Index = index,
                BirthDate = DateOnly.Parse(birthDate),
                Name = name,
                Sex = gender == "1",
                Type = type,
                Race = race,
            };

            if (adopted == "1")
            {
                animal.IsAdopted = oldAnimal.IsAdopted;
            }
            else
            {
                animal.IsAdopted = false;
            }
            
            TestDatabaseTODELETE.ANIMALS[index] = animal;
            return RedirectToAction("Index", "Home");
        }

    }
}
