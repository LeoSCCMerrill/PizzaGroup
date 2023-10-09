using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaGroup.Data;
using PizzaGroup.Models;

namespace PizzaGroup.Controllers
{
    [Authorize(Roles = "Owner, Manager")]
    public class ManagementController : Controller
    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;
        public ManagementController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await GetViewModel());
        }
        public IActionResult CreateEmployee()
        {
            return View(new User());
        }

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

        public async Task<IActionResult> DemoteManager(string userId)
        {
            User user = await userManager.FindByIdAsync(userId);
            await userManager.RemoveFromRoleAsync(user, "Manager");
            await userManager.AddToRoleAsync(user, "Employee");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> PromoteEmployee(string userId)
        {
            User user = await userManager.FindByIdAsync(userId);
            await userManager.RemoveFromRoleAsync(user, "Employee");
            await userManager.AddToRoleAsync(user, "Manager");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteEmployee(string userId)
        {
            await userManager.DeleteAsync(await userManager.FindByIdAsync(userId));
            return RedirectToAction("Index");
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

        public  IActionResult CreateNewPizza()
        {
            return View();
        }
    }
}
