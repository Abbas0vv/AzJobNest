using AzJobNest.Database.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AzJobNest.Database;

public class AzJobNetDbContext : IdentityDbContext<AzJobNetUser>
{
    public AzJobNetDbContext(DbContextOptions<AzJobNetDbContext> options) : base(options) { }


    public DbSet<Notification> Notifications { get; set; }
    public DbSet<BroadcastMessage> BroadcastMessages { get; set; }
}
