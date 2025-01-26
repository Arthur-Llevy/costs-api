using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Api.Domain.Services;

public class ProjectsCategoryServices : ProjectsCategoryInterface
{
    private readonly DatabaseContext _context;
    public ProjectsCategoryServices(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<List<ProjectsCategory>?> GetAll()
    {
        var result = await _context.ProjectsCategory.ToListAsync();

        if (result != null)
        {
            List<ProjectsCategory> categories = new List<ProjectsCategory>();

            foreach(ProjectsCategory item in result)
            {
                categories.Add(new ProjectsCategory
                    {
                        Id = item.Id,
                        Name = item.Name      
                    }
                );
            }
            return categories;
        }
        return null;
    }
}