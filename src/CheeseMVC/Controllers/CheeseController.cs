﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;


namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private static Dictionary<string, string> Cheeses = new Dictionary<string, string>();
        
        public IActionResult Index()
        {
            ViewBag.cheeses = Cheeses;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name, string description)
        {
            // Add the new cheese to existing cheeses
            Cheeses.Add(name, description);

            return Redirect("/Cheese");

        }

        [HttpPost]
        [Route("/Cheese/Delete")]
        public IActionResult DeleteCheese(string cheese)
        {
            Cheeses.Remove(cheese);
            return Redirect("/Cheese");
        }
    }
}
