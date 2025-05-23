using Microsoft.AspNetCore.Mvc;

namespace AzJobNest.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
