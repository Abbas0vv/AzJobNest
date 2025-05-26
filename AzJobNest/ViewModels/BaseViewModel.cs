using AzJobNest.ViewModels.Account;
using AzJobNest.ViewModels.Account.Advanced;

namespace AzJobNest.ViewModels;

public class BaseViewModel
{
    public UpdateAdvancedProfileViewModel? UpdateProfile { get; set; }
    public CreateAdvancedProfileViewModel? CreateProfile { get; set; }
    public BasicRegisterViewModel? RegisterViewModel { get; set; }
    public LoginViewModel? LoginViewModel { get; set; }
}
