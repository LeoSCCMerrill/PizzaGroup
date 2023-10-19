
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PizzaGroup.Data;
using PizzaGroup.Models;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace PizzaGroup.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult Index(int PizzaID)
        {
            var defaultPizzas = _context.Pizzas.Select(p => p.PizzaID == PizzaID);

            return View(defaultPizzas);
        }

        public IActionResult ViewOrder() {
            var pOrder = _context.Orders.ToList();
            return View(pOrder);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([Bind("customerID, PizzaID")] Order o) {
            //Use this to add to Orders in the Database
            
                _context.Orders.Add(o);
                await _context.SaveChangesAsync();
                return RedirectToAction("ndex");

        }

        public async Task<IActionResult> Edit(int Id) 
        {
            var std =  _context.Orders.Where(o => o.CustomerID == Id).FirstOrDefault();
            return RedirectToAction("Index");
        }
    }
}
