
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PizzaGroup.Data;
using PizzaGroup.Models;
using System.Reflection.Metadata.Ecma335;

namespace PizzaGroup.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context) {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewOrder() { 
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder([Bind("customerID, PizzaID")] Order o) {
            //Use this to add to Orders in the Database
            
                _context.Add(o);
                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            
         
        }
        
    }
}
