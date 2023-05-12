﻿using Microsoft.AspNetCore.Mvc;
using PinkPanther.Models;
using System;
using System.Diagnostics;
using System.Reflection;

namespace PinkPanther.Controllers
{
    public class TypeController : Controller
    {
        private readonly List<TypeViewModel> _types = TestDatabaseTODELETE.TYPES;
        private int _index;
        public IActionResult Index()
        {
            return View(_types); 
        }
        public IActionResult Modify(int index)
        {
            _index = index;
            var type = _types.Where(type => type.Index == index).First();
            return View(type);
        }
        public IActionResult ChangeType(string type)
        {
            //send changes to database
            var typevm = new TypeViewModel() { Index = _index, Type = type };

            TestDatabaseTODELETE.TYPES[_index] = typevm;


            return RedirectToAction("Index", "Type");
        }
    }
}
