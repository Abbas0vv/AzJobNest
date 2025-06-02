using AzJobNest.Database.DomainModels;
using System.Security.Claims;
using AzJobNest.ViewModels.Account;
using Microsoft.AspNetCore.Identity;

namespace AzJobNest.Services.Abstract;

public interface IUserService
{
    Task<IdentityResult> Register(RegisterViewModel model);
    Task<bool> Login(LoginViewModel model);
    Task LogOut();
    Task CreateRole();
    Task<AzJobNestUser> GetCurrentUserAsync(ClaimsPrincipal user);
    Task<IdentityResult> UpdateProfileAsync(ClaimsPrincipal userPrincipal, UpdateProfileViewModel model);
}
