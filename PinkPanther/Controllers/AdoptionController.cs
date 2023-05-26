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
                Animals = _mapper.Map(_manager.GetAnimals(null, null)),
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

        public IActionResult AdoptSend()
        {
            //send data to database (_adoption)
            return RedirectToAction("Index", "Adoption");
        }
    }
}
