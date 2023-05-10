using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;

namespace PinkPanther.Controllers
{
    public class ClientsController : Controller
    {
        private readonly List<ClientViewModel> _clients = TestDatabaseTODELETE.CLIENTS;
        public IActionResult Index()
        {
            return View(_clients);
        }
    }
}
