using AzJobNest.Database.DomainModels;
using AzJobNest.Helpers.Enums;
using AzJobNest.Services.Abstract;
using AzJobNest.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AzJobNest.Services.Concretes;

public class UserService : IUserService
{
    private readonly UserManager<AzJobNestUser> _userManager;
    private readonly SignInManager<AzJobNestUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(UserManager<AzJobNestUser> userManager, SignInManager<AzJobNestUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task<bool> Login(LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user is not null)
        {
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (result)
            {
                await _signInManager.SignInAsync(user, true);
                return true;
            }
        }

        return false;
    }

    public async Task LogOut()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<IdentityResult> Register(RegisterViewModel model)
    {
        var user = new AzJobNestUser()
        {
            Name = model.Name,
            LastName = model.Lastname,
            UserName = model.UserName,
            Email = model.Email,
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, model.SelectedRole.ToString());
            await _signInManager.SignInAsync(user, true);
        }

        return result;
    }

    public async Task CreateRole()
    {
        foreach (var item in Enum.GetValues(typeof(Role)))
        {
            await _roleManager.CreateAsync(new IdentityRole()
            {
                Name = item.ToString()
            });
        }
    }

}
