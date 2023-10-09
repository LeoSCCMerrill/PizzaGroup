using Microsoft.AspNetCore.Mvc;

namespace PizzaGroup.Controllers
{
    public class CustomPizzaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
