﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaGroup.Data;
using System.Reflection;

namespace PizzaGroup.Controllers
{
    public class CustomerController : Controller

    {
        private readonly ApplicationDbContext _context;

        public CustomerController (ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomPizzaView()
        {
            return View();
        }

        [Authorize(Roles="Manager")]
        [HttpPost]
        public IActionResult DeletePizza(int PizzaID)
        {
            var pizza = _context.Pizzas.Find(PizzaID);

            _context.Pizzas.Remove(pizza);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
