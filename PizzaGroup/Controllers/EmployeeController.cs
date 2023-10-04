using Microsoft.AspNetCore.Mvc;

namespace PizzaGroup.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
