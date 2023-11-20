
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PizzaGroup.Data;
using PizzaGroup.Models;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Session;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace PizzaGroup.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public const string SessionKeyOrder = "_Order";
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

        [HttpGet]
        public IActionResult PizzaStatus(int status)
        {
            Order? order = HttpContext.Session.Get<Order>(SessionKeyOrder);
            //var currentStatus = _context.Orders.


            //currentStatus.OrderStatus = (OrderStatus)status;

            if (order == null)
            {
                RedirectToAction("Index");
            }

            
            return View(order);
        }

        public IActionResult ViewOrder()
        {
            //Get this fixed

            Order? order = HttpContext.Session.Get<Order>(SessionKeyOrder);
            decimal grandTotal = 0;


            if (order == null) {
                ViewBag.Total = null;
            }else
            {
                foreach (var item in order.PizzaList)
                {
                    grandTotal += item.Price;

                }
                ViewBag.Total = grandTotal;
            }

            return View(order);


        }


        public IActionResult Edit(int Id)
        {
            var eInfo = _context.Orders.Find(Id);
            return View(eInfo);
        }

        public async Task<IActionResult> SubmitOrder()
        {
            if (HttpContext == null || HttpContext.Session == null || HttpContext.Session.Get<Order>(SessionKeyOrder) == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Order orderSession = HttpContext.Session.Get<Order>(SessionKeyOrder);
            Order order = new()
            {
                CustomerId = orderSession.CustomerId,
                EmployeeId = orderSession.EmployeeId,
            };
            if (!(order.EmployeeId.Length > 0))
            {
                await AssignToEmployee(order);
            }
            if (!(order.EmployeeId.Length > 0))
            {
                return RedirectToAction("Index", "Home");
            }
            order.OrderStatus = OrderStatus.ASSIGNED;
            _context.Add(order);
            _context.SaveChanges();
            foreach (var pizza in orderSession.Pizzas)
            {
                OrderPizza orderPizza = new()
                {
                    Quantity = pizza.Value,
                    PizzaId = pizza.Key,
                    OrderId = order.Id,
                };
                _context.OrderPizzas.Add(orderPizza);
            }
            _context.SaveChanges();
            HttpContext.Session.Remove(SessionKeyOrder);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            Order order = HttpContext.Session.Get<Order>(SessionKeyOrder);  // The button shouldn't pop up unless there is something add validation just in case later
            IList<Pizza> pizzaList = order.PizzaList;
            IDictionary<int, int> pizzaDictionary = order.Pizzas;
            var pizza = pizzaList.FirstOrDefault(p => p.Id == id);
            if (pizzaDictionary[id] > 1)
            {
                pizzaDictionary[id]--;
            } else
            {
                pizzaDictionary.Remove(id);
            }
            
            pizzaList.Remove(pizza);
            HttpContext.Session.Set(SessionKeyOrder, order);
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
            Order? order = HttpContext.Session.Get<Order>(SessionKeyOrder);
            if (order == null)
            {
                order = new Order
                {
                    CustomerId = id,
                    EmployeeId = ""
                };
                HttpContext.Session.Set<Order>(SessionKeyOrder, order);
            }
            if (order.Pizzas.ContainsKey(pizza.Id))
            {
                order.Pizzas[pizza.Id]++;
            }
            else
            {
                order.Pizzas.Add(pizza.Id, 1);
            }
            order.PizzaList.Add(pizza);
            HttpContext.Session.Set<Order>(SessionKeyOrder, order);

            return RedirectToAction("ViewOrder");

        }
        private async Task AssignToEmployee(Order order)
        {
            IList<Order> orders = _context.Orders.ToList();
            IDictionary<string, int> employeeAssignments = (await userManager.GetUsersInRoleAsync("Employee")).ToDictionary(u=>u.Id, u=>0);
            if (employeeAssignments.Count > 0)
            {
                foreach (Order orderElement in orders)
                {
                    if (orderElement.OrderStatus == OrderStatus.OUT_FOR_DELIVERY ||
                        orderElement.OrderStatus == OrderStatus.ASSIGNED ||
                        orderElement.OrderStatus == OrderStatus.FINAL_CHECK ||
                        orderElement.OrderStatus == OrderStatus.ADDING_TOPPINGS ||
                        orderElement.OrderStatus == OrderStatus.BAKING_PIZZAS ||
                        orderElement.OrderStatus == OrderStatus.TOSSING_DOUGH)
                    {
                        employeeAssignments[orderElement.EmployeeId]++;
                    }
                }
                string assigneeId = employeeAssignments.MinBy(kvp => kvp.Value).Key;
                if (assigneeId != null)
                {
                    order.EmployeeId = assigneeId;
                    return;
                }
            }
            order.EmployeeId = "";
        }

        public IActionResult PayNow() {


            return View();
        }

        [HttpPost]
        public IActionResult ProcessPayment()
        {

            return View("ThankYou");
        }
        public IActionResult ThankYou()
        {
            return View();
        }


    }
}
public static class SessionExtensions
{
    public static void Set<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T? Get<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default : JsonSerializer.Deserialize<T>(value);
    }
}



