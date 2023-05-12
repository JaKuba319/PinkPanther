using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;

namespace PinkPanther.Controllers
{
    public class ClientsController : Controller
    {
        private readonly List<ClientViewModel> _clients = TestDatabaseTODELETE.CLIENTS;
        public IActionResult Index(string filterString, string genderFilter)
        {
            if(string.IsNullOrEmpty(filterString) && string.IsNullOrEmpty(genderFilter))
            {
                return View(_clients);
            }
            var clients = (IEnumerable<ClientViewModel>)_clients;
            if(string.IsNullOrEmpty(genderFilter))
            {
                filterString = filterString.Trim().ToLower();
                clients = clients.Where(client => client.Name.ToLower().Contains(filterString) || client.LastName.ToLower().Contains(filterString));
            }
            else if(string.IsNullOrEmpty(filterString))
            {
                if (genderFilter == "1")
                {
                    clients = clients.Where(client => client.Sex);
                }
                else
                {
                    clients = clients.Where(client => !client.Sex);
                }
            }
            else
            {
                if (genderFilter == "1")
                {
                    clients = clients.Where(client => client.Sex);
                }
                else
                {
                    clients = clients.Where(client => !client.Sex);
                }
                filterString = filterString.Trim().ToLower();
                clients = clients.Where(client => client.Name.ToLower().Contains(filterString) || client.LastName.ToLower().Contains(filterString));
            }
            
            return View(clients);
        }

        public IActionResult Add(string clientName, string lastName, string clientBirthDate, string phoneNumber, string clientGender)
        {

            return RedirectToAction("Index", "Clients");
        }
    }
}
