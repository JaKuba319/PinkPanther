using Microsoft.AspNetCore.Mvc;
using PinkPanther.Core;
using PinkPanther.Mappers;
using PinkPanther.Models;
using System.Linq;

namespace PinkPanther.Controllers
{
    public class AdoptionController : Controller
    {
        readonly ViewModelMapper _mapper;
        readonly IManager _manager;
        public AdoptionController(IManager manager, ViewModelMapper mapper)
        {
            _mapper = mapper;
            _manager = manager;
        }
        public IActionResult Index(int id)
        {
            var adoptionData = new AdoptionDataViewModel
            {
                Animals = _mapper.Map(_manager.GetAnimals(null, null)).Where(animal => animal.Client == null),
                Clients = _mapper.Map(_manager.GetClients(null)),
            };

            if(id != 0)
            {
                adoptionData.SelectedAnimal = _mapper.Map(_manager.GetAnimalById(id));
            }

            return View(adoptionData);
        }

        public IActionResult AdoptConfirmation(int animalId, int clientId)
        {

            var adoption = new AdoptionViewModel()
            {
                Animal = _mapper.Map(_manager.GetAnimalById(animalId)),
                Client = _mapper.Map(_manager.GetClientById(clientId))
            };

            return View(adoption);
        }

        public IActionResult AdoptSend(int animalId, int clientId)
        {
            var animalDto = _manager.GetAnimalById(animalId);
            var clientDto = _manager.GetClientById(clientId);

            _manager.AddAdoption(animalDto, clientDto);
            return RedirectToAction("Index", "Adoption");
        }
    }
}
