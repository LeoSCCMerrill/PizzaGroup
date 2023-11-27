using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaGroup.Data;
using PizzaGroup.Models;
using System.Diagnostics;

namespace PizzaGroup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TestPizzaView(int id)
        {
            Pizza? model = _context.Pizzas.Include(p => p.PizzaToppings).ThenInclude(pt => pt.Topping)
                                          .Include(p => p.Size)
                                          .Include(p => p.Crust)
                                          .FirstOrDefault(p => p.Id == id);
            return View(model);
        }
    }
}