using Api.Utils.Classes;

namespace Api.Domain.DTOs;

public class ProjectsDTO
{
    public string Name { get; set; } = default!;
    public int Budget { get; set; } = default;
    public int Costs { get; set; } = default!;
    public Category Category { get; set; } = default!;
}