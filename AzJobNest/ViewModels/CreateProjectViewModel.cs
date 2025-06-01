using System.ComponentModel.DataAnnotations;

namespace AzJobNest.ViewModels;

public class CreateProjectViewModel
{
    [Required]
    [Display(Name = "Project Name")]
    public string Name { get; set; }

    [Display(Name = "Project Description")]
    public string? Description { get; set; }

    [Required]
    [Url]
    [Display(Name = "Repository URL")]
    public string RepositoryUrl { get; set; }

    [Url]
    [Display(Name = "Deployment URL")]
    public string? DeploymentUrl { get; set; }

    [Required]
    [Display(Name = "Source")]
    public string Source { get; set; }
}
