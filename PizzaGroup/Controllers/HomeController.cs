﻿using Microsoft.AspNetCore.Mvc;
using PizzaGroup.Data;
using PizzaGroup.Models;
using System.Diagnostics;

namespace PizzaGroup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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
        public  IActionResult TestPizzaView()
        {
            var theToppings =  _context.PizzaToppings
                .Where(pt => pt.PizzaID == 1)
                .ToList();
            var theModel = new PizzaViewModel
            {
                Pizza = _context.Pizzas.First(),
                PizzaToppings = theToppings,
                Toppings = _context.Toppings.ToList()
            };
            return View(theModel);
        }
    }
}