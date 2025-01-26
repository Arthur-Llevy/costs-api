using Api.Domain.Entities;

namespace Api.Domain.ModelViews;

public class ProjectsModelView
{
    public int Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public int Budget { get; set; } = default;
    public int Costs { get; set; } = default!;
    public ProjectsCategory Category { get; set; } = default!;
    public ICollection<ProjectServicesEntity> Services { get; set; } = default!;
}