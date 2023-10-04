using Microsoft.AspNetCore.Mvc;

namespace PizzaGroup.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
