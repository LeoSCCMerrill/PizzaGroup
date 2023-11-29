using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using PizzaGroup.Data;
using PizzaGroup.Models;
using System.Security.Claims;

namespace PizzaGroup.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CustomerController> _logger;
        private readonly IDictionary<int, Crust> _crusts;
        private readonly IDictionary<int, Size> _sizes;
        private readonly IDictionary<int, Topping> _toppings;

        public CustomerController(RoleManager<IdentityRole> roleManager, ApplicationDbContext context, ILogger<CustomerController> logger)
        {
            _roleManager = roleManager;
            _context = context;
            _logger = logger;
            _crusts = _context.Crusts.ToDictionary(crust => crust.Id, crust => crust);
            _sizes = _context.Sizes.ToDictionary(size => size.Id, size => size);
            _toppings = _context.Toppings.ToDictionary(topping => topping.Id, topping => topping);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogDebug("CustomerController.Index");
            IList<Pizza> pizzas = _context.Pizzas.Include(p => p.Size)
                .Include(p => p.Crust)
                .Include(p => p.PizzaToppings).ThenInclude(pt => pt.Topping).ToList();
            return View(pizzas);
        }

        [AllowAnonymous]
        [HttpGet]  // retrieve the list of pizzas
        public IActionResult ListPizzas()
        {
            _logger.LogDebug("CustomerController.ListPizzas");
            DateTime currentTime = DateTime.Now;
            bool isShopOpen = IsShopOpen(currentTime);
            if (!isShopOpen)
            {
                _logger.LogDebug("CustomerController.ListPizzas: Shop is Closed");
                return RedirectToAction("WereClosed");
            }
            _logger.LogDebug("CustomerController.ListPizzas: Shop is Open");
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IList<Pizza> pizzas = _context.Pizzas.Include(p => p.Size)
                .Include(p => p.Crust)
                .Include(p => p.PizzaToppings).ThenInclude(pt => pt.Topping)
                .Where(p => p.UserId == null)
                .ToList();
            if (userId != null)
            {
                IList<Pizza> userPizzas = _context.Pizzas.Include(p => p.Size)
                .Include(p => p.Crust)
                .Include(p => p.PizzaToppings).ThenInclude(pt => pt.Topping)
                .Where(p => p.UserId == userId)
                .ToList();

                pizzas.AddRange(userPizzas);
            }
            return View(pizzas);
        }

        [HttpGet]
        public IActionResult PizzaStatus()
        {
            _logger.LogDebug("CustomerController.PizzaStatus");
            return View();
        }

        private static bool IsShopOpen(DateTime currentTime)
        {
            DayOfWeek dayOfWeek = currentTime.DayOfWeek;
            TimeSpan currentTimeOfDay = currentTime.TimeOfDay;
            // Check if it's Sunday (shop is closed on Sundays)
            if (dayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            // Check if the time is outside of the shop's opening hours (Monday - Saturday, 10:30 am to 9:00 pm)
            TimeSpan openingTime = new(10, 30, 0);
            TimeSpan closingTime = new(21, 0, 0);
            if (currentTimeOfDay < openingTime || currentTimeOfDay > closingTime)
            {
                return false;
            }
            return true;
        }

        [HttpGet]
        public IActionResult CustomPizzaView()
        {
            _logger.LogDebug("CustomerController.CustomPizzaView - Get Method");
            ViewBag.Sizes = _sizes.Values;
            ViewBag.Crusts = _crusts.Values;
            ViewBag.Toppings = _toppings.Values;
            IList<ToppingList> toppingList = new List<ToppingList>();
            foreach (Topping topping in _toppings.Values)
            {
                toppingList.Add(new ToppingList { Topping = topping, IsSelected = false });
            }
            var theModel = new CustomizeViewModel
            {
                Pizza = new Pizza
                {
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                },
                ToppingList = toppingList
            };
            return View(theModel);
        }

        [HttpPost]
        public IActionResult CustomPizzaView(CustomizeViewModel model)
        {
            _logger.LogDebug("CustomerController.CustomPizzaView - Post Method");
            if (ModelState.IsValid)
            {
                _context.Add(model.Pizza);
                _context.SaveChanges();
                decimal price = 0.0m;
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
                price += _crusts[(int)model.Pizza.CrustId].Price;
                price += 10.0m;
                price *= _sizes[(int)model.Pizza.SizeId].PriceMultiplier;
                Pizza? pizza = _context.Pizzas.Include(p => p.Size).Include(p => p.Crust).FirstOrDefault(p => p.Id == model.Pizza.Id);
                pizza.Price = price;
                _context.Pizzas.Update(pizza);
                _context.SaveChanges();
                return RedirectToAction("ListPizzas");
            }
            _logger.LogDebug("CustomerController.CustomPizzaView - PostMethod: Invalid Model State");
            ViewBag.Sizes = _sizes.Values;
            ViewBag.Crusts = _crusts.Values;
            ViewBag.Toppings = _toppings.Values;
            return View(model);
        }

        [HttpGet]
        public IActionResult DeletePizza(int id)
        {
            _logger.LogDebug("CustomerController.DeletePizza - Get Method");
            ViewBag.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Pizza model = _context.Pizzas.Include(p => p.PizzaToppings).ThenInclude(pt => pt.Topping)
                    .Include(p => p.Size)
                    .Include(p => p.Crust)
                    .FirstOrDefault(p => p.Id == id) ?? new Pizza();
            return View(model);
        }

        [HttpPost]
        public IActionResult DeletePizza(Pizza model)
        {
            _logger.LogDebug("CustomerController.DeletePizza - Post Method");
            if (model != null)
            {
                var pizzaId = model.Id;
                _context.Pizzas.Remove(model);
                _context.PizzaToppings.Where(pt => pt.PizzaId == pizzaId).ToList().ForEach(pt => _context.PizzaToppings.Remove(pt));
                _context.SaveChanges();
            }
            return RedirectToAction("ListPizzas");
        }

        [HttpPost]
        public IActionResult Add(Pizza model)
        {
            _logger.LogDebug("CustomerController.Add");
            if (ModelState.IsValid)
            {
                // Add the pizza to the database
                _context.Pizzas.Add(model);
                _context.SaveChanges();

                return RedirectToAction("ListPizzas"); // Redirect to the ListPizzas
            }
            _logger.LogDebug("CustomerController.Add: Invalid Model State");
            return View("ListPizzas", model); // Show the form with validation errors
        }

        // If the shop is not open do not allow the customer to start an order
        [HttpGet]
        public IActionResult WereClosed()
        {
            _logger.LogDebug("CustomerController.WereClosed");
            return View();
        }
    }
}
