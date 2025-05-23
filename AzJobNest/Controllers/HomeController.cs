using Microsoft.AspNetCore.Mvc;

namespace AzJobNest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
