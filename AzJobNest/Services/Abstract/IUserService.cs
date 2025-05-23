using AzJobNest.ViewModels.Account;

namespace AzJobNest.Services.Abstract;

public interface IUserService
{
    Task Register(RegisterViewModel model);
    Task Login(LoginViewModel model);
    Task LogOut();
    Task CreateRole();
}
