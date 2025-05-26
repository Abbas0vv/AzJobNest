using System.ComponentModel.DataAnnotations;
using AzJobNest.Helpers.Enums;

namespace AzJobNest.ViewModels.Account.Advanced;

public class UpdateAdvancedProfileViewModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }
    [MinLength(3)]
    public string UserName { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    public string? ImageUrl { get; set; }
}
