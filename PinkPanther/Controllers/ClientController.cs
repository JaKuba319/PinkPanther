using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;
using System;
using System.Diagnostics;

namespace PinkPanther.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index(int index)
        {
            var client = TestDatabaseTODELETE.CLIENTS.Where(client => client.Index == index).FirstOrDefault();
            if(client == null) return RedirectToAction("Index","Clients");
            return View(client);
        }

        public IActionResult Delete(int index)
        {
            var client = TestDatabaseTODELETE.CLIENTS.Where(client => client.Index == index).FirstOrDefault();
            if (client == null) return RedirectToAction("Index", "Clients");
            TestDatabaseTODELETE.CLIENTS.Remove(client);
            return RedirectToAction("Index", "Clients");
        }

        public IActionResult Modify(int index)
        {
            var client = TestDatabaseTODELETE.CLIENTS.Where(client => client.Index == index).FirstOrDefault();
            if (client == null) return RedirectToAction("Index", "Clients");
            return View(client);
        }
        public IActionResult Change(int index, string firstName, string lastName, string gender, string birthDate, string phoneNumber)
        {
            // add validation
            var oldClient = TestDatabaseTODELETE.CLIENTS.Where(client => client.Index == index).FirstOrDefault();
            if (oldClient == null) return RedirectToAction("Index", "Clients");

            var client = new ClientViewModel()
            {
                Index = index,
                Name = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Sex = gender == "1",
                BirthDate = DateOnly.Parse(birthDate),
                Animals = oldClient.Animals
            };

            TestDatabaseTODELETE.CLIENTS[index] = client;
            return RedirectToAction("Index", "Clients");
        }

    }
}
