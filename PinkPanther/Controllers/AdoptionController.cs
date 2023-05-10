using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;
using System.Linq;

namespace PinkPanther.Controllers
{
    public class AdoptionController : Controller
    {
        private readonly List<AnimalViewModel> _animals = TestDatabaseTODELETE.ANIMALS.Where(animal => !animal.IsAdopted).ToList();

        private readonly List<ClientViewModel> _clients = TestDatabaseTODELETE.CLIENTS;
        public IActionResult Index(int index)
        {
            var adoptionData = new AdoptionDataViewModel 
            { 
                Animals = _animals,
                Clients = _clients,
                SelectedAnimal = _animals.Where(animal => animal.Index == index).FirstOrDefault()
            };

            return View(adoptionData);
        }

        public IActionResult Adopt(int animalIndex, int clientIndex)
        {

            return View();
        }
    }
}
