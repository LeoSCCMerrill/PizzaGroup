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
        public IActionResult UpdateStatus(Order order, int status)
        {
            //Temp to see what is easier seding the Order ID or the whole Order
            //Order order = _context.Orders.Find(orderId);

            if (order == null)
            {
                return NotFound();
            }

            order.OrderStatus = (OrderStatus)status;
            _context.Orders.Update(order);
            _context.SaveChanges();
            return RedirectToAction("Details", order);
        }
        [HttpGet]
        public IActionResult DeleteOrder(int id)
        {
            return View(id);
        }
        [HttpPost]
        [ActionName("DeleteOrder")]
        public IActionResult DeleteOrderPost(int id)
        {
            Order order = _context.Orders.Include(o => o.OrderPizza).FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                if(order.EmployeeId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                {
                    if(order.OrderStatus != OrderStatus.DELIVERED)
                    {
                        foreach(OrderPizza op in order.OrderPizza)
                        {
                            _context.OrderPizzas.Remove(op);
                        }
                        _context.Orders.Remove(order);
                        _context.SaveChanges();
                    } else
                    {
                        return RedirectToAction("BadDelete");
                    }         
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("BadDelete");
            }
        }
        public IActionResult BadDelete()
        {
            return View();
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
