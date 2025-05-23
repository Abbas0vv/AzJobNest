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
    private readonly UserManager<AzJobNetUser> _userManager;
    private readonly SignInManager<AzJobNetUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(UserManager<AzJobNetUser> userManager, SignInManager<AzJobNetUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
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

    public async Task Login(LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user is not null)
        {
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (result)
                await _signInManager.SignInAsync(user, true);
        }
    }

    public async Task LogOut()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task Register(RegisterViewModel model)
    {
        int count = await _userManager.Users.CountAsync();

        var user = new AzJobNetUser()
        {
            Name = model.UserName,
            LastName = model.Lastname,
            UserName = model.UserName,
            Email = model.Email,
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            if (count == 0)
                await _userManager.AddToRoleAsync(user, Role.Admin.ToString());
            else
                await _userManager.AddToRoleAsync(user, Role.User.ToString());

            await _signInManager.SignInAsync(user, true);
        }
    }

}
