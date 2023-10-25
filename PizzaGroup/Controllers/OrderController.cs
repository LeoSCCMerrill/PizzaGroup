
using Microsoft.AspNetCore.Authorization;
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
            //Get this fixed

            string Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Order? pOrder = _context.Orders.Where(o => o.CustomerId == Id).FirstOrDefault();
            
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
        public async Task<IActionResult> AddOrder(int pizzaId)
        {
            Pizza? pizza = _context.Pizzas.Find(pizzaId);
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (pizza == null)
            {
                return NotFound();
            }
            
            Order? order = _context.Orders.Where(o => o.CustomerId == id).FirstOrDefault();
            
            if (order == null)
            {
                order = new Order();
                order.CustomerId = id;
                order.EmployeeId = "Somethign New";
                order.OrderStatus = "10 Minutes";
                order.Pizzas.Add(pizza);
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }
            order.Pizzas.Add(pizza);

            return RedirectToAction("ViewOrder", order);

        }
    }
}
