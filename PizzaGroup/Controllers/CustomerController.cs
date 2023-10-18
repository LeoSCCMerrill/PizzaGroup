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

        [HttpGet]
        public IActionResult CustomPizzaView()
        {
            ViewBag.Sizes = _context.Sizes.ToList();
            ViewBag.Crusts = _context.Crusts.ToList();
            ICollection<Topping> toppings = _context.Toppings.ToList();
            IDictionary<Topping, bool> toppingDict = new Dictionary<Topping, bool>();
            foreach (Topping topping in toppings)
            {
                toppingDict.Add(topping, false);
            }
            Pizza pizza = new();
            CustomizeViewModel theModel = new()
            {
                Pizza = pizza,
                ToppingDictionary = toppingDict
            };
            return View(theModel);
        }
        [HttpPost]
        public IActionResult CustomPizzaView(CustomizeViewModel model)
        {
            foreach (KeyValuePair<Topping, bool> topping in model.ToppingDictionary) {
                if (topping.Value)
                {
                    model.Pizza.Toppings.Add(topping.Key);
                }
            }
            _context.Add(model.Pizza);
            _context.SaveChanges();
            return RedirectToAction("Index");
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
