using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaGroup.Data;
using PizzaGroup.Models;

namespace PizzaGroup.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext _context;
        UserManager<User> userManager;
        public IActionResult Index()
        {
            IList<Order> orders = new List<Order>();
            _context.Orders.Where(o => o.EmployeeID == 1);
            return View();
        }
    }
}
