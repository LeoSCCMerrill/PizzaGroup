﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaGroup.Data;
using System.Reflection;
using PizzaGroup.Models;
using Microsoft.AspNetCore.Identity;

namespace PizzaGroup.Controllers
{
    public class CustomerController : Controller

    {
        private RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;

        public CustomerController (RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            this.roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CustomPizzaView()
        {
            ViewBag.Sizes = _context.Sizes.ToList();
            ViewBag.Crusts = _context.Crusts.ToList();
            ViewBag.Toppings = _context.Toppings.ToList();
            var theModel = new Pizza();
            return View(theModel);
        }
        [HttpPost]
        public IActionResult CustomPizzaView(Pizza model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> DeletePizza(int PizzaID)
        {
            var pizza = await _context.Pizzas.FindAsync(PizzaID);

            if (pizza == null)
            {
                return NotFound();
            }

            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
    }
}
