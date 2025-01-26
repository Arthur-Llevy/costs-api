using Api.Domain.Entities;

namespace Api.Domain.Interfaces;

public interface ProjectsCategoryInterface
{
    Task<List<ProjectsCategory>?> GetAll();
}