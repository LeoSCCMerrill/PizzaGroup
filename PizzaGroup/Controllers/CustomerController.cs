using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaGroup.Data;
using System.Reflection;
using PizzaGroup.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace PizzaGroup.Controllers
{
    public class CustomerController : Controller

    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;
        

        public CustomerController (RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            this.roleManager = roleManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IList<Pizza> pizzas = _context.Pizzas.Include(p => p.Size)
                .Include(p => p.Crust)
                .Include(p => p.PizzaToppings).ThenInclude(pt => pt.Topping).ToList();
            return View(pizzas);
        }


        [HttpGet]  // retrieve the list of pizzas
        public IActionResult ListPizzas()
        {
            IList<Pizza> pizzas = _context.Pizzas.Include(p => p.Size).ToList();
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
                Pizza = new Pizza
                {
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                },
                ToppingList = theList
            };
            return View(theModel);
        }
        [HttpPost]
        public IActionResult CustomPizzaView(CustomizeViewModel model)
        {
            if(ModelState.IsValid)
            {
                _context.Add(model.Pizza);
                _context.SaveChanges();
                foreach (ToppingList entry in model.ToppingList)
                {
                    if (entry.IsSelected == true)
                    {
                        PizzaTopping pizzaTopping = new PizzaTopping
                        {
                            PizzaId = model.Pizza.Id,
                            ToppingId = entry.Topping.Id,
                        };
                        _context.PizzaToppings.Add(pizzaTopping);
                    }
                }
                _context.SaveChanges();
                
                return RedirectToAction("ListPizzas");
            } else
            {
                ViewBag.Sizes = _context.Sizes.ToList();
                ViewBag.Crusts = _context.Crusts.ToList();
                ViewBag.Toppings = _context.Toppings.ToList();
                return View(model);
            }
            
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public IActionResult DeletePizza(int? Id)
        {
            var pizza = _context.Pizzas.Find(Id);

            if (pizza == null)
            {
                return NotFound();
            }

            _context.Pizzas.Remove(pizza);
            _context.SaveChanges();
            
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

        // If the shop is not open do not allow the customer to start an order
        [HttpPost]
        public IActionResult WereClosed()
        {
            var rightNow = DateTime.Now;
            return View(); 
        }
    }
}
