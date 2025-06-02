using AzJobNest.Database;
using AzJobNest.Database.DomainModels;
using AzJobNest.Services.Abstract;
using AzJobNest.ViewModels.Project;
using Microsoft.EntityFrameworkCore;

namespace AzJobNest.Services.Concretes;

public class ProjectService : IProjectService
{
    private readonly AzJobNestDbContext _context;

    public ProjectService(AzJobNestDbContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> GetAllAsync()
    {
        return await _context.Projects.OrderBy(p => p.Id).ToListAsync();
    }

    public async Task<Project> GetByIdAsync(int? id)
    {
        return await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task Insert(CreateProjectViewModel model)
    {
        var project = new Project()
        {
            Name = model.Name,
            Description = model.Description,
            DeploymentUrl = model.DeploymentUrl,
            RepositoryUrl = model.RepositoryUrl,
            Source = model.Source,
        };

        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int? id, UpdateProjectViewModel model)
    {
        if (id is null) return;
        var project = await GetByIdAsync(id);

        project.Name = model.Name;
        project.Description = model.Description;
        project.DeploymentUrl = model.DeploymentUrl;
        model.RepositoryUrl = model.RepositoryUrl;
        model.Source = model.Source;

        _context.Update(project);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int? id)
    {
        if (id is null) return;
        _context.Remove(id);
        await _context.SaveChangesAsync();
    }
}
