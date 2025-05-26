using System.ComponentModel.DataAnnotations;
using AzJobNest.Helpers.Enums;

namespace AzJobNest.ViewModels.Account.Advanced;

public class CreateAdvancedProfileViewModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }
    public IFormFile? File { get; set; }

}
