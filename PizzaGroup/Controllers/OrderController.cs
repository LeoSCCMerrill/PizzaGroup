
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

        public IActionResult ViewOrder()
        {
            //Get this fixed

            Order order = HttpContext.Session.Get<Order>(SessionKeyOrder);


            return View(order);


        }


        public IActionResult Edit(int Id)
        {
            var eInfo = _context.Orders.Find(Id);
            return View(eInfo);
        }

        public IActionResult SubmitOrder()
        {
            
            Order order = HttpContext.Session.Get<Order>(SessionKeyOrder);
            if(order.PizzaList.Count > 0)
            {
                Order order2 = new Order
                {
                    CustomerId = order.CustomerId,
                    EmployeeId = order.EmployeeId,
                };
                _context.Add(order2);


                _context.SaveChanges();

                foreach (var pizza in order.Pizzas)
                {
                    OrderPizza orderPizza = new()
                    {
                        Quantity = pizza.Value,
                        PizzaId = pizza.Key,
                        OrderId = order2.Id,
                    };
                    _context.OrderPizzas.Add(orderPizza);
                }

                _context.SaveChanges();
            }

            return RedirectToAction("index", "Home");
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
                    EmployeeId = "Something New"
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

            return View("ViewOrder", order);

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



