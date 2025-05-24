using AzJobNest.Helpers.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AzJobNest.Controllers;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            if (User.IsInRole(Role.Freelancer.ToString()))
                return RedirectToAction(nameof(FreelancerDashboard));
            else if (User.IsInRole(Role.Employer.ToString()))
                return RedirectToAction(nameof(EmployerDashboard));
        }

        return View();
    }

    [Authorize(Roles = "Freelancer")]
    public ActionResult FreelancerDashboard()
    {
        return View();
    }

    [Authorize(Roles = "Employer")]
    public ActionResult EmployerDashboard()
    {
        return View();
    }
}
