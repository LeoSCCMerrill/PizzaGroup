using Microsoft.AspNetCore.Authorization;
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

        public IActionResult Add() 
        { 
            return View();
        }

        public IActionResult CustomPizzaView()
        {
            var theModel = new CustomizeViewModel
            {
                Pizza = new Pizza { },
                Sizes = _context.Sizes.ToList(),
                Crusts = _context.Crusts.ToList(),
                Toppings = _context.Toppings.ToList()
            };
            return View(theModel);
        }

        [Authorize(Roles = "Manager")]
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
