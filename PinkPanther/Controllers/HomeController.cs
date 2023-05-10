﻿using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;
using System.Diagnostics;

namespace PinkPanther.Controllers
{
    public class HomeController : Controller
    {
        // List of animals available to adopt
        private readonly List<AnimalViewModel> _animals = TestDatabaseTODELETE.ANIMALS;

        public IActionResult Index(bool adoptedOnly = false)
        {
            if (adoptedOnly) return View(_animals.Where(animal => animal.IsAdopted).ToList());

            return View(_animals);
        }

        public IActionResult ViewSingleAnimal(int indexOfAnimal)
        {
            return RedirectToAction("Index", "Animal", new { index = indexOfAnimal });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}