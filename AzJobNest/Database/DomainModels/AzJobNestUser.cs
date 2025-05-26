using AzJobNest.Database.Abstracts;
using AzJobNest.Helpers.Enums;
using Microsoft.AspNetCore.Identity;

namespace AzJobNest.Database.DomainModels;

public class AzJobNestUser : IdentityUser, IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }

    //public List<Notification> Notifications { get; set; }
}
