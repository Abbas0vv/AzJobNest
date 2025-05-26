using AzJobNest.Services.Abstract;
using AzJobNest.ViewModels;
using AzJobNest.ViewModels.Account;
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
        var model = new BaseViewModel
        {
            RegisterViewModel = new BasicRegisterViewModel()
        };
        return View(model);

    }

    [HttpPost]
    public async Task<IActionResult> Register(BaseViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var result = await _userService.Register(model.RegisterViewModel);

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
        var model = new BaseViewModel
        {
            LoginViewModel = new LoginViewModel()
        };
        return View(model);

    }

    [HttpPost]
    public async Task<IActionResult> Login(BaseViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var loginSuccess = await _userService.Login(model.LoginViewModel);
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
    public async Task<IActionResult> CreateRole()
    {
        await _userService.CreateRole();
        return RedirectToAction("Index", "Home");
    }
}
