using System.ComponentModel.DataAnnotations;
using AzJobNest.Helpers.Enums;

namespace AzJobNest.ViewModels.Account;

public class BasicRegisterViewModel
{
    [MinLength(3)]
    public string UserName { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DataType(DataType.Password), Compare(nameof(Password))]
    public string ConfirmPasswor { get; set; }
    [Required]
    public Role SelectedRole { get; set; } // "Employer" və ya "Freelancer"

}
