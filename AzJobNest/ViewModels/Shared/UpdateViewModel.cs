using AzJobNest.ViewModels.Account;
using AzJobNest.ViewModels.Project;

namespace AzJobNest.ViewModels.Shared;

public class UpdateViewModel
{
    public UpdateProfileViewModel? UpdateProfileViewModel { get; set; }
    public CreateProjectViewModel? CreateProjectViewModel { get; set; }
    public List<Database.DomainModels.Project>? Projects { get; set; }
}
