using Microsoft.AspNetCore.Mvc;

namespace AzJobNest.Controllers;

public class ProfileController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
