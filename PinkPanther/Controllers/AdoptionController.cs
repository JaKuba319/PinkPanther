using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;
using System.Linq;

namespace PinkPanther.Controllers
{
    public class AdoptionController : Controller
    {
        private readonly List<AnimalViewModel> _animals = TestDatabaseTODELETE.ANIMALS.Where(animal => !animal.IsAdopted).ToList();

        private readonly List<ClientViewModel> _clients = TestDatabaseTODELETE.CLIENTS;

        private AdoptionViewModel? _adoption;
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

        public IActionResult AdoptConfirmation(int animalIndex, int clientIndex)
        {

            var adoption = new AdoptionViewModel()
            {
                Animal = TestDatabaseTODELETE.ANIMALS.Where(animal => animal.Index == animalIndex).First(),
                Client = TestDatabaseTODELETE.CLIENTS.Where(client => client.Index == clientIndex).First(),
            };
            _adoption = adoption;

            return View(_adoption);
        }

        public IActionResult AdoptSend()
        {
            //send data to database (_adoption)
            return RedirectToAction("Index", "Adoption");
        }
    }
}
