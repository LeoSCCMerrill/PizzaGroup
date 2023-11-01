
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


        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int pizza)
        {
            //I don't know why i made it to delete the entire order. Needs to remove the pizza.  Fix Later.
            //Order order = _context.Orders.Find(id);
            //_context.Orders.Remove(order);
            //_context.SaveChanges();

            Order order = HttpContext.Session.Get<Order>(SessionKeyOrder);  // The button shouldn't pop up unless there is something add validation just in case later

            IList<Pizza> p = order.Pizzas;
            p.Remove(p[pizza]);
            //order.Pizzas.Remove();
            HttpContext.Session.Set(SessionKeyOrder, order);
            return RedirectToAction("ViewOrder", order);
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
            
            if (HttpContext.Session.Get<Order>(SessionKeyOrder) == null)
                {
                if (order == null)
                {
                    order = new Order();
                    order.CustomerId = id;
                    order.EmployeeId = "Something New";
                    order.OrderStatus = 10;
                    //order.Pizzas.Add(pizza);

                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                
                order = HttpContext.Session.Get<Order>(SessionKeyOrder);
                
                //order.Pizzas.Add(pizza);
            }

            order.Pizzas.Add(pizza); //Shouldn't be able to get a null?
            
            HttpContext.Session.Set(SessionKeyOrder, order);
            
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

    

