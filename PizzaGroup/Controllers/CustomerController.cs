using Microsoft.AspNetCore.Mvc;

namespace PizzaGroup.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomPizzaView()
        {
            return View();
        }
    }
}
