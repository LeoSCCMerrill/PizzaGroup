
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaGroup.Data;
using PizzaGroup.Models;

namespace PizzaGroup.Controllers
{
    [Authorize(Roles = "Owner, Manager")]
    public class ManagementController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ManagementController> _logger;
        private readonly IDictionary<int, Crust> _crusts;
        private readonly IDictionary<int, Size> _sizes;
        private readonly IDictionary<int, Topping> _toppings;
        public ManagementController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context, ILogger<ManagementController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _logger = logger;
            _crusts = _context.Crusts.ToDictionary(crust => crust.Id, crust => crust);
            _sizes = _context.Sizes.ToDictionary(size => size.Id, size => size);
            _toppings = _context.Toppings.ToDictionary(topping => topping.Id, topping => topping);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await GetViewModel());
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View(new User());
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(User user)
        {
            user.EmailConfirmed = true;
            user.Email = user.UserName;
            user.NormalizedEmail = user.NormalizedUserName;
            await _userManager.CreateAsync(user, user.PasswordHash);
            await _userManager.AddToRoleAsync(user, "Employee");
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DemoteManager(string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            await _userManager.RemoveFromRoleAsync(user, "Manager");
            await _userManager.AddToRoleAsync(user, "Employee");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> PromoteEmployee(string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            await _userManager.RemoveFromRoleAsync(user, "Employee");
            await _userManager.AddToRoleAsync(user, "Manager");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(string userId)
        {
            await _userManager.DeleteAsync(await _userManager.FindByIdAsync(userId));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateNewPizza()
        {
            ViewBag.Sizes = _sizes.Values;
            ViewBag.Crusts = _crusts.Values;
            ViewBag.Toppings = _toppings.Values;
            List<ToppingList> theList = new();
            foreach (Topping topping in _toppings.Values)
                theList.Add(new ToppingList { Topping = topping, IsSelected = false });
            var theModel = new CustomizeViewModel
            {
                Pizza = new Pizza { },
                ToppingList = theList
            };
            return View(theModel);
        }

        [HttpPost]
        public IActionResult CreateNewPizza(CustomizeViewModel model)
        {
            if (ModelState.IsValid)
            {
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
                price += _crusts[model.Pizza.CrustId].Price;
                price += 10.0m;
                price *= _sizes[model.Pizza.SizeId].PriceMultiplier;
                model.Pizza.Price = price;
                _context.ChangeTracker.Clear();
                _context.Add(model.Pizza);
                _context.SaveChanges();
                return RedirectToAction("ListPizzas");
            }
            else
            {
                ViewBag.Sizes = _sizes.Values;
                ViewBag.Crusts = _crusts.Values;
                ViewBag.Toppings = _toppings.Values;
                return View(model);
            }

        }
        public IActionResult ToppingsControls()
        {
            List<Topping> model = _context.Toppings.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult EditTopping(int id)
        {
            var model = _context.Toppings.FirstOrDefault(t => t.Id == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditTopping(Topping model)
        {
            if (ModelState.IsValid)
            {
                Topping? topping = _context.Toppings.Find(model.Id);
                if (topping == null)
                    return View(model);
                topping.Name = model.Name;
                topping.Price = model.Price;
                topping.ToppingType = model.ToppingType;
                _context.SaveChanges();
                return RedirectToAction("ToppingsControls");
            }
            else
                return View(model);
        }

        [HttpGet]
        public IActionResult AddTopping()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTopping(Topping model)
        {
            if (ModelState.IsValid)
            {
                _context.Toppings.Add(model);
                _context.SaveChanges();
                return RedirectToAction("ToppingsControls");
            }
            else
                return View(model);
        }

        [HttpGet]
        public IActionResult DeleteTopping(int id)
        {
            var model = _context.Toppings.FirstOrDefault(t => t.Id == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteTopping(Topping model)
        {
            _context.ChangeTracker.Clear();
            _context.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("ToppingsControls");
        }

        [HttpGet]
        public IActionResult DeletePizza(int id)
        {
            ViewBag.UserId = null;
            Pizza model = _context.Pizzas.Include(p => p.PizzaToppings).ThenInclude(pt => pt.Topping)
                                         .Include(p => p.Size)
                                         .Include(p => p.Crust)
                                         .FirstOrDefault(p => p.Id == id) ?? new Pizza();
            return View(model);
        }
        [HttpPost]
        public IActionResult DeletePizza(Pizza model)
        {
            if (model != null)
            {
                var pizzaId = model.Id;
                _context.Pizzas.Remove(model);
                foreach (var pt in _context.PizzaToppings.Where(pt => pt.PizzaId == pizzaId).ToList())
                    _context.PizzaToppings.Remove(pt);
                _context.SaveChanges();
            }
            return RedirectToAction("ListPizzas", "Customer");
        }

        [HttpPost]
        public IActionResult Add(Pizza model)
        {
            if (ModelState.IsValid)
            {
                _context.Pizzas.Add(model);
                _context.SaveChanges();
                return RedirectToAction("TestPizzaView");
            }
            return View("CreateNewPizza", model); // Show the form with validation errors
        }

        [Authorize(Roles = "Owner, Manager")]
        [HttpGet]
        public IActionResult EditPizza(int id)
        {
            Pizza? pizza = _context.Pizzas.Include(p => p.Size).Include(p => p.Crust).FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

        [Authorize(Roles = "Owner, Manager")]
        [HttpPost]
        public IActionResult EditPizza(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                _context.Pizzas.Update(pizza);
                _context.SaveChanges();
                return RedirectToAction("ListPizzas", "Customer");
            }
            return View(pizza);
        }

        [Authorize(Roles = "Owner, Manager")]
        [HttpGet]
        public IActionResult LimitedTimeDeal(int id)
        {
            var StartDate = ViewBag.StartDate ?? DateTime.Today;
            var EndDate = ViewBag.EndDate ?? DateTime.Today;
            
                

            // Retrieve the selected Pizza by its Id
            var pizza = _context.Pizzas.Include(p => p.Size).Include(p => p.Crust).FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

        private async Task<UserViewModel> GetViewModel()
        {
            IList<User> users = new List<User>();
            foreach (User user in _userManager.Users)
            {
                user.RoleNames = await _userManager.GetRolesAsync(user);
                users.Add(user);
            }
            UserViewModel model = new()
            {
                Users = users,
                Roles = _roleManager.Roles.ToList()
            };
            return model;
        }
    }
}
