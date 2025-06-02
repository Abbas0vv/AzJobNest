using AzJobNest.ViewModels.Project;
using Microsoft.AspNetCore.Mvc;

namespace AzJobNest.Controllers
{
    public class ProjectController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> CreateProject()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectViewModel model)
        {
            if (!ModelState.IsValid) return View(model);



            return RedirectToAction("EditProfile", "Account");
        }
    }
}
