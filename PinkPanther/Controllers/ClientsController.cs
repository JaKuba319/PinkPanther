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
            if (client == null) return RedirectToAction("Index");
            return View(_mapper.Map(client));
        }


        [HttpPost]
        public IActionResult Add(ClientViewModel clientViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            _manager.AddClient(_mapper.Map(clientViewModel));

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _manager.DeleteClient(id);
            return RedirectToAction("Index");
        }

        public IActionResult GoToModify(int id)
        {
            var clientDto = _manager.GetClientById(id);
            var clientVM = _mapper.Map(clientDto);

            if (clientVM == null) return RedirectToAction("Index");
            return View("Modify", clientVM);
        }

        public IActionResult Modify(ClientViewModel clientViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var clientDto = _mapper.Map(clientViewModel);

            _manager.UpdateClient(clientDto);

            return RedirectToAction("Index");
        }
    }
}
