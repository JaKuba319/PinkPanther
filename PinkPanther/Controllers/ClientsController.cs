using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;

namespace PinkPanther.Controllers
{
    public class ClientsController : Controller
    {
        private readonly List<ClientViewModel> _clients = TestDatabaseTODELETE.CLIENTS;
        public IActionResult Index(string filterString)
        {
            return View(_clients.Where(client => client.Name.Contains(filterString) || client.LastName.Contains(filterString)).ToList());
        }
    }
}
