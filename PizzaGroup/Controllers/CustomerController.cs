using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaGroup.Data;
using System.Reflection;
using PizzaGroup.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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


        [HttpGet]  // retrieve the list of pizzas
        public IActionResult ListPizzas()
        {
            List<Pizza> pizzas = _context.Pizzas.Include(p => p.Size).ToList();
            return View(pizzas);
        }
        
        [HttpGet]
        public IActionResult CustomPizzaView()
        {
            ViewBag.Sizes = _context.Sizes.ToList();
            ViewBag.Crusts = _context.Crusts.ToList();
            ViewBag.Toppings = _context.Toppings.ToList();
            List<ToppingList> theList = new List<ToppingList>(); 
            foreach(Topping topping in _context.Toppings)
            {
                theList.Add(new ToppingList { Topping = topping, IsSelected=false});
            }
            var theModel = new CustomizeViewModel
            {
                Pizza = new Pizza(),
                ToppingList = theList
            };
            return View(theModel);
        }
        [HttpPost]
        public IActionResult CustomPizzaView(CustomizeViewModel model)
        {
            _context.Add(model.Pizza);
            _context.SaveChanges();
            foreach (ToppingList entry in model.ToppingList)
            {
               if (entry.IsSelected == true) 
                {
                    PizzaTopping pizzaTopping = new PizzaTopping
                    {
                        PizzaId = model.Pizza.PizzaId,
                        ToppingId = entry.Topping.ToppingID,
                    };
                    _context.PizzaToppings.Add(pizzaTopping);
                }
            }
            _context.SaveChanges();
            return RedirectToAction("ListPizzas");
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
            
            return RedirectToAction("ListPizzas");
        }

        [HttpPost]
        public IActionResult Add(Pizza model)
        {
            if (ModelState.IsValid)
            {
                // Add the pizza to the database
                _context.Pizzas.Add(model);
                _context.SaveChanges();

                return RedirectToAction("ListPizzas"); // Redirect to the ListPizzas
            }

            return View("ListPizzas", model); // Show the form with validation errors
        }
    }
}
