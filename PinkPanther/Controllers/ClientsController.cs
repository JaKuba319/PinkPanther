using Microsoft.AspNetCore.Mvc;
using PinkPanther.Core;
using PinkPanther.Mappers;
using PinkPanther.Models;

namespace PinkPanther.Controllers
{
    public class ClientsController : Controller
    {
        readonly ViewModelMapper _mapper;
        readonly IManager _manager;
        public ClientsController(IManager manager, ViewModelMapper mapper)
        {
            _mapper = mapper;
            _manager = manager;
        }
        public IActionResult Index(string filterString, string genderFilter)
        {
            IEnumerable<ClientDto> clients;

            if (!string.IsNullOrEmpty(genderFilter))
            {
                clients = _manager.GetClients(filterString, genderFilter == "1");
            }
            else
            {
                clients = _manager.GetClients(filterString);
            }

            return View(_mapper.Map(clients));
        }

        public IActionResult ViewSingleClient(int id)
        {
            var client = _manager.GetClientById(id);
            if (client == null) return RedirectToAction("Index", "Clients");
            return View(_mapper.Map(client));
        }


        //[HttpPost]
        public IActionResult Add(string firstName, string lastName, string birthDate, string phoneNumber, string email, string clientGender)
        {
            // add validation 
            if (firstName == null || lastName == null || !DateOnly.TryParse(birthDate, out var date))
            {
                //error
                return RedirectToAction("Index", "Clients");
            }

            var client = new ClientViewModel()
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Email = email,
                Gender = clientGender == "1",
                BirthDate = date
            };

            _manager.AddClient(_mapper.Map(client));

            return RedirectToAction("Index", "Clients");
        }

        //[HttpDelete]
        public IActionResult Delete(int id)
        {
            _manager.DeleteClient(id);
            return RedirectToAction("Index", "Clients");
        }

        public IActionResult Modify(int id)
        {
            var client = _manager.GetClientById(id);
            if (client == null) return RedirectToAction("Index", "Clients");
            return View(_mapper.Map(client));
        }

        //[HttpPut]
        public IActionResult Change(int id, string firstName, string lastName, string gender, string birthDate, string phoneNumber, string email)
        {
            // add validation
            if (firstName == null || lastName == null || !DateOnly.TryParse(birthDate, out var date))
            {
                //error
                return RedirectToAction("Index", "Clients");
            }

            var oldClient = _manager.GetClientById(id);
            if (oldClient == null) return RedirectToAction("Index", "Clients");

            var client = new ClientViewModel()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Email = email,
                Gender = gender == "1",
                BirthDate = DateOnly.Parse(birthDate),
                Animals = _mapper.Map(oldClient.Animals)
            };

            _manager.UpdateClient(_mapper.Map(client));

            return RedirectToAction("Index", "Clients");
        }
    }
}
