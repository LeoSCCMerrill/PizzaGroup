using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            IList<Order> orders = _context.Orders.Where(o => o.EmployeeId.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier)) && o.OrderStatus != OrderStatus.DELIVERED).ToList();
            return View(orders);
        }
        [HttpGet]
        public IActionResult Details(Order order)
        {
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
            if (order != null) { 
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
