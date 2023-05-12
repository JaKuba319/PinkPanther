using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;
using System;
using System.Diagnostics;
using System.Reflection;

namespace PinkPanther.Controllers
{
    public class TypeController : Controller
    {
        private readonly List<TypeViewModel> _types = TestDatabaseTODELETE.TYPES;
        public IActionResult Index()
        {
            return View(_types); 
        }
        public IActionResult Modify(int index)
        {
            var type = _types.Where(type => type.Index == index).FirstOrDefault();
            if(type != null)
            {
                return View(type);
            }
            return RedirectToAction("Index", "Type");
        }
        public IActionResult ChangeType(int index, string type)
        {
            //send changes to database
            var typevm = new TypeViewModel() { Index = index, Type = type };

            TestDatabaseTODELETE.TYPES[index] = typevm;


            return RedirectToAction("Index", "Type");
        }

        public IActionResult Delete(int index)
        {
            var toDelete = TestDatabaseTODELETE.TYPES.Where(type => type.Index == index).FirstOrDefault();
            if(toDelete == null) return RedirectToAction("Index", "Type");
            TestDatabaseTODELETE.TYPES.Remove(toDelete);
            return RedirectToAction("Index", "Type");
        }
    }
}
