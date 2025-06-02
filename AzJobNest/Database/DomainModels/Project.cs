using AzJobNest.Database.Abstracts;

namespace AzJobNest.Database.DomainModels;

public class Project : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }
    public string RepositoryUrl { get; set; }
    public string? DeploymentUrl { get; set; }
    public string Source { get; set; }
}
