using Microsoft.AspNetCore.Mvc;

namespace PizzaGroup.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
