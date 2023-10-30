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

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    IList<Order> orders = _context.Orders.Where(o => o.EmployeeId.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier)) && o.OrderStatus != OrderStatus.DELIVERED).ToList();
        //    return View(orders);
        //}
        [HttpGet]
        public IActionResult Details(int orderId)
        {
            Order order = _context.Orders.Find(orderId);
            return View(order);
        }
        [HttpPost]
        public IActionResult UpdateStatus(int orderId, OrderStatus status)
        {
            Order order = _context.Orders.Find(orderId);
            if (order != null) { 
                //order.OrderStatus = status;
            }
            _context.SaveChanges();
            return RedirectToAction("Details", orderId);
        }
        [HttpPost]
        public IActionResult Delete(int orderId)
        {
            _context.Orders.Remove(_context.Orders.Find(orderId));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
