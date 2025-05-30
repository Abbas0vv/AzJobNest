using System.Security.Claims;
using AzJobNest.Services.Abstract;
using AzJobNest.ViewModels;
using AzJobNest.ViewModels.Account;
using AzJobNest.ViewModels.Account.Advanced;
using Microsoft.AspNetCore.Mvc;

namespace AzJobNest.Controllers;
public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
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
        if (user == null) return RedirectToAction(nameof(Login));

        var model = new EditProfileViewModel
        {
            UserName = user.UserName,
            Name = user.Name,
            MiddleName = user.MiddleName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            LinkedInUrl = user.LinkedInUrl,
            GitHubUrl = user.GitHubUrl,
            Gender = user.Gender,
            BirthDate = user.BirthDate,
            ProfilePicture = user.ProfilePicture,
            CV = user.CV
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditProfile(EditProfileViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var result = await _userService.UpdateProfileAsync(User, model);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        TempData["SuccessMessage"] = "Profile updated successfully!";
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> CreateRole()
    {
        await _userService.CreateRole();
        return RedirectToAction("Index", "Home");
    }
}
