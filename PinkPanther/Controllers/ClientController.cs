using Microsoft.AspNetCore.Mvc;

namespace PinkPanther.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index(int indexOfClient)
        {
            var clientvm = TestDatabaseTODELETE.CLIENTS.Where(client => client.Index == indexOfClient).FirstOrDefault();
            if(clientvm == null) return RedirectToAction("Index","Clients");
            return View(clientvm);
        }
    }
}
