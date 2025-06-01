using AzJobNest.Database.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AzJobNest.Database;

public class AzJobNestDbContext : IdentityDbContext<AzJobNestUser>
{
    public AzJobNestDbContext(DbContextOptions<AzJobNestDbContext> options) : base(options) { }

    public DbSet<Project> Projects { get; set; } 
}
