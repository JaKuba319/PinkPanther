using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;
using System;

namespace PinkPanther.Controllers
{
    public class TypeController : Controller
    {
        private readonly List<string> _types = TestDatabaseTODELETE.ANIMALS.Select(x => x.Type).Distinct().ToList();
        public IActionResult Index()
        {
            return View(_types); 
        }
    }
}
