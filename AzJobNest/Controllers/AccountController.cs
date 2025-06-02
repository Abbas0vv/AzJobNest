using System.Security.Claims;
using AzJobNest.Services.Abstract;
using AzJobNest.ViewModels.Account;
using AzJobNest.ViewModels.Project;
using AzJobNest.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AzJobNest.Controllers;
public class AccountController : Controller
{
    private readonly IUserService _userService;
    private readonly IProjectService _projectService;
    public AccountController(IUserService userService, IProjectService projectService)
    {
        _userService = userService;
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<IActionResult> Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var result = await _userService.Register(model);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        return RedirectToAction(nameof(Login));
    }

    [HttpGet]
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var loginSuccess = await _userService.Login(model);
        if (!loginSuccess)
        {
            ModelState.AddModelError(string.Empty, "Email or password is incorrect.");
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }


    [HttpGet]
    public async Task<IActionResult> LogOut()
    {
        await _userService.LogOut();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> EditProfile()
    {
        var user = await _userService.GetCurrentUserAsync(User);
        var projects = await _projectService.GetAllAsync();
        if (user == null) return RedirectToAction(nameof(Login));

        var model = new UpdateViewModel
        {
            UpdateProfileViewModel = new UpdateProfileViewModel()
            {
                UserName = user.UserName,
                Name = user.Name,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                BirthDate = user.BirthDate,
                ProfilePicture = user.ProfilePicture,
                CV = user.CV
            },
            CreateProjectViewModel = new CreateProjectViewModel(),
            Projects = projects
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditProfile(UpdateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var result = await _userService.UpdateProfileAsync(User, model.UpdateProfileViewModel);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            var user = await _userService.GetCurrentUserAsync(User);
            var projects = await _projectService.GetAllAsync();

            var fullModel = new UpdateViewModel
            {
                UpdateProfileViewModel = model.UpdateProfileViewModel,
                CreateProjectViewModel = new CreateProjectViewModel(),
                Projects = projects
            };

            return View(fullModel);
        }

        TempData["SuccessMessage"] = "Profile updated successfully!";
        return RedirectToAction(nameof(EditProfile));
    }

    [HttpGet]
    public async Task<IActionResult> CreateRole()
    {
        await _userService.CreateRole();
        return RedirectToAction("Index", "Home");
    }
}
