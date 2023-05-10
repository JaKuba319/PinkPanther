using Microsoft.AspNetCore.Mvc;

namespace PinkPanther.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index(int indexOfClient)
        {
            return View(TestDatabaseTODELETE.CLIENTS.Where(client => client.Index == indexOfClient).FirstOrDefault());
        }
    }
}
