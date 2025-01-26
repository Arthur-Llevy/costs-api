using Api.Domain.DTOs;
using Api.Domain.Entities;
using Api.Domain.ModelViews;
using Api.Domain.Services;

namespace Api.Domain.Interfaces;

public interface ProjectsInterface
{
    Task<List<ProjectsModelView>?> GetAll();
    Task<ProjectsModelView?> GetById(int id);
    Task<ProjectsModelView> CreateNewProject(ProjectsDTO projectDTO);
    Task<ProjectsModelView?> DeleteOneProject(int id);
    Task<ProjectsModelView?> UpdateOneProject(int id, ProjectsDTO projectDTO);
    Task AddOneService(int id, List<ProjectsServicesDTO> projectsServicesDTO);
    Task<ProjectsServicesDTO?> DeleteOneService(int id);
}
