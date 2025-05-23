using AzJobNest.Database.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace AzJobNest.Database.DomainModels;

public class AzJobNetUser : IdentityUser, IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    //public List<Notification> Notifications { get; set; }
}
