using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaGroup.Data;
using System.Reflection;
using PizzaGroup.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using NuGet.Packaging;

namespace PizzaGroup.Controllers
{
    public class CustomerController : Controller

    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;
        private readonly IDictionary<int, Crust> _crusts;
        private readonly IDictionary<int, Size> _sizes;
        private readonly IDictionary<int, Topping> _toppings;

        public CustomerController (RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            this.roleManager = roleManager;
            _context = context;
            _crusts = _context.Crusts.ToDictionary(crust => crust.Id, crust => crust);
            _sizes = _context.Sizes.ToDictionary(size => size.Id, size => size);
            _toppings = _context.Toppings.ToDictionary(topping => topping.Id, topping => topping);
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

            DateTime currentTime = DateTime.Now;
            bool isShopOpen = IsShopOpen(currentTime);

            if (!isShopOpen)
            {
                return RedirectToAction("WereClosed");
            } else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                IList<Pizza> pizzas = _context.Pizzas.Include(p => p.Size)
                .Include(p => p.Crust)
                .Include(p => p.PizzaToppings).ThenInclude(pt => pt.Topping)
                .Where(p => p.UserId == null)
                .ToList();

                IList<Pizza> userPizzas = _context.Pizzas.Include(p => p.Size)
                .Include(p => p.Crust)
                .Include(p => p.PizzaToppings).ThenInclude(pt => pt.Topping)
                .Where(p => p.UserId == userId)
                .ToList();

                pizzas.AddRange(userPizzas);
                return View(pizzas);
            }
            
        }

        private bool IsShopOpen(DateTime currentTime)
        {
            DayOfWeek dayOfWeek = currentTime.DayOfWeek;
            TimeSpan currentTimeOfDay = currentTime.TimeOfDay;

            // Check if it's Sunday (shop is closed on Sundays)
            if (dayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }

            // Check if the time is outside of the shop's opening hours (Monday - Saturday, 10:30 am to 9:00 pm)
            TimeSpan openingTime = new TimeSpan(10, 30, 0);
            TimeSpan closingTime = new TimeSpan(21, 0, 0);

            if (currentTimeOfDay < openingTime || currentTimeOfDay > closingTime)
            {
                return false;
            }

            return true;
        }

        [HttpGet]
        public IActionResult CustomPizzaView()
        {
            ViewBag.Sizes = _sizes.Values;
            ViewBag.Crusts = _crusts.Values;
            ViewBag.Toppings = _toppings.Values;
            List<ToppingList> theList = new List<ToppingList>(); 
            foreach(Topping topping in _toppings.Values)
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
                Decimal price = 0.0m;
                foreach (ToppingList entry in model.ToppingList)
                {
                    if (entry.IsSelected == true)
                    {
                        PizzaTopping pizzaTopping = new()
                        {
                            PizzaId = model.Pizza.Id,
                            ToppingId = entry.Topping.Id,
                        };
                        price += entry.Topping.Price;
                        _context.PizzaToppings.Add(pizzaTopping);
                    }
                }
                price += _crusts[model.Pizza.CrustId].Price;
                price += 10.0m;
                price *= _sizes[model.Pizza.SizeId].PriceMultiplier;
                model.Pizza.Price = price;
                _context.Update(model.Pizza);
                _context.SaveChanges();
                
                return RedirectToAction("ListPizzas");
            } else
            {
                ViewBag.Sizes = _sizes.Values;
                ViewBag.Crusts = _crusts.Values;
                ViewBag.Toppings = _toppings.Values;
                return View(model);
            }
            
        }

        [HttpGet]
        public IActionResult DeletePizza(int id)
        {
            ViewBag.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Pizza model = _context.Pizzas.Include(p => p.PizzaToppings).ThenInclude(pt => pt.Topping)
                .Include(p => p.Size)
                .Include(p => p.Crust)
                .FirstOrDefault(p => p.Id == id);
            return View(model);
        }
        [HttpPost]
        public IActionResult DeletePizza(Pizza model)
        {
            if(model != null)
            {
                var pizzaId = model.Id;
                _context.Pizzas.Remove(model);
                foreach (var pt in _context.PizzaToppings.Where(pt => pt.PizzaId == pizzaId).ToList())
                {
                    _context.PizzaToppings.Remove(pt);
                }
                _context.SaveChanges();
            }
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
        [HttpGet]
        public IActionResult WereClosed()
        {
            return View(); 
        }
    }
}
