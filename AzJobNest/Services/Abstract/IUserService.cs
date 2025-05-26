using AzJobNest.ViewModels.Account;
using Microsoft.AspNetCore.Identity;

namespace AzJobNest.Services.Abstract;

public interface IUserService
{
    Task<IdentityResult> Register(BasicRegisterViewModel model);
    Task<bool> Login(LoginViewModel model);
    Task LogOut();
    Task CreateRole();
}
