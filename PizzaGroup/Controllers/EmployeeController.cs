using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaGroup.Data;
using PizzaGroup.Models;
using System.Security.Claims;

namespace PizzaGroup.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IList<Order> orders = _context.Orders.Include(o => o.OrderPizza).ThenInclude(op => op.Pizza).ThenInclude(p => p.Crust)
                                                 .Include(o => o.OrderPizza).ThenInclude(op => op.Pizza).ThenInclude(p => p.Size)
                                                 .Include(o => o.OrderPizza).ThenInclude(op => op.Pizza).ThenInclude(p => p.PizzaToppings)
                                                 .ThenInclude(pt => pt.Topping)
                                                 .Where(o => o.EmployeeId.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier)) && o.OrderStatus != OrderStatus.DELIVERED).ToList();
            return View(orders);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Order order = _context.Orders.Include(o => o.OrderPizza).ThenInclude(op => op.Pizza).ThenInclude(p => p.Crust)
                                                 .Include(o => o.OrderPizza).ThenInclude(op => op.Pizza).ThenInclude(p => p.Size)
                                                 .Include(o => o.OrderPizza).ThenInclude(op => op.Pizza).ThenInclude(p => p.PizzaToppings)
                                                 .ThenInclude(pt => pt.Topping).Where(o => o.Id == id).FirstOrDefault();
            return View(order);
        }
        [HttpPost]
        public IActionResult EditOrder(Order order)
        {
            return View(order);
        }
        [HttpPost]
        public IActionResult UpdateStatus(Order order, OrderStatus status)
        {
            if (order != null)
            {
                //order.OrderStatus = status;
            }
            _context.Update(order);
            _context.SaveChanges();
            return RedirectToAction("Details", order);
        }
        [HttpPost]
        public IActionResult Delete(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
