
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PizzaGroup.Data;
using PizzaGroup.Models;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace PizzaGroup.Controllers
{
    public class OrderController : Controller
    {

        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;
        public OrderController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this._context = context;
        }

        public IActionResult Index(int PizzaId)
        {
            var defaultPizzas = _context.Pizzas.Select(p => p.Id == PizzaId);

            return View(defaultPizzas);
        }

        public IActionResult ViewOrder()
        {
            List<Order> pOrder = _context.Orders.ToList();
            return View(pOrder);
        }
        public IActionResult Edit(int Id)
        {
            var eInfo = _context.Orders.Find(Id);
            return View(eInfo);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            Order order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction("ViewOrder");
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(Pizza pizza, string id)
        {
            //Use this to add to Orders in the Database

            Order? order = _context.Orders.Where(o => o.CustomerId == id).FirstOrDefault();

            if (order == null)
            {
                order.CustomerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //order.EmployeeId = 
                //order.OrderStatus //Employee edits;
                order.Pizzas.Add(pizza);

            }
            else
            {
                order.Pizzas.Add(pizza);
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("index");

        }



    }
}
