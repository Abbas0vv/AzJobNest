using AzJobNest.Database.DomainModels;
using AzJobNest.ViewModels.Project;
using Microsoft.EntityFrameworkCore;

namespace AzJobNest.Services.Abstract;

public interface IProjectService
{
    Task<List<Project>> GetAllAsync();
    Task<Project> GetByIdAsync(int? id);
    Task Insert(CreateProjectViewModel model);
    Task Update(int? id, UpdateProjectViewModel model);
    Task Delete(int? id);
}
