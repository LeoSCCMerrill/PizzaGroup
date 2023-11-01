
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
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;
        public ManagementController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _context = context;
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
            await userManager.CreateAsync(user);
            await userManager.AddToRoleAsync(user, "Employee");
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DemoteManager(string userId)
        {
            User user = await userManager.FindByIdAsync(userId);
            await userManager.RemoveFromRoleAsync(user, "Manager");
            await userManager.AddToRoleAsync(user, "Employee");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> PromoteEmployee(string userId)
        {
            User user = await userManager.FindByIdAsync(userId);
            await userManager.RemoveFromRoleAsync(user, "Employee");
            await userManager.AddToRoleAsync(user, "Manager");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(string userId)
        {
            await userManager.DeleteAsync(await userManager.FindByIdAsync(userId));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public  IActionResult CreateNewPizza()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Pizza model)
        {
            if (ModelState.IsValid)
            {
                // Add the pizza to the database
                _context.Pizzas.Add(model);
                _context.SaveChanges();

                return RedirectToAction("TestPizzaView"); // Redirect to the TestPizzaView
            }

            return View("CreateNewPizza", model); // Show the form with validation errors
        }

        [Authorize(Roles = "Owner, Manager")]
        [HttpGet]
        public IActionResult EditPizza(int id)
        {
            
            // Retrieve the selected Pizza by its Id
            var pizza = _context.Pizzas.Include(p => p.Size).Include(p => p.Crust).FirstOrDefault(p => p.Id == id);
           
            return View(pizza);

        }
        [Authorize(Roles = "Owner, Manager")]
        [HttpPost]
        public IActionResult EditPizza(Pizza pizza, Crust crust)
        {
              
            if (ModelState.IsValid)
            { 
 
                _context.Pizzas.Update(pizza);
                _context.SaveChanges();

                return RedirectToAction("ListPizzas", "Customer");
            }
            return View(pizza);
        }


        private async Task<UserViewModel> GetViewModel()
        {
            IList<User> users = new List<User>();
            foreach (User user in userManager.Users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
                users.Add(user);
            }
            UserViewModel viewModel = new()
            {
                Users = users,
                Roles = roleManager.Roles
            };
            return viewModel;
        }

    }
   
}
