using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;
using System.Diagnostics;

namespace PinkPanther.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        // List of animals available to adopt
        private readonly List<AnimalViewModel> Animals = new List<AnimalViewModel>()
        {
            new AnimalViewModel()
            {
                Name = "Burek",
                Type = "Dog",
                Race = "Akita",
                Sex = true,
                BirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-8)),
                IsAdopted = false
            },
            new AnimalViewModel()
            {
                Name = "Jazz",
                Type = "Dog",
                Race = "Mongrel",
                Sex = true,
                BirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-3)),
                IsAdopted = false
            },
            new AnimalViewModel()
            {
                Name = "Funny",
                Type = "Cat",
                Race = "Bengal cat",
                Sex = false,
                BirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-6)),
                IsAdopted = false
            }
        };


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(Animals);
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