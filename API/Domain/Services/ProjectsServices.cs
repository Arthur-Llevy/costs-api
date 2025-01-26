using Api.Domain.DTOs;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.ModelViews;
using Api.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Api.Domain.Services;

public class ProjectsServices : ProjectsInterface
{
    private readonly DatabaseContext _context;

    public ProjectsServices(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<List<ProjectsModelView>?> GetAll()
    {
        var result = await _context.Projects
        .Include(x => x.Services)
        .Include(x => x.Category)
        .ToListAsync();

        List<ProjectsModelView> projects = new List<ProjectsModelView>();
        
        foreach(var item in result)
        {
            projects.Add(new ProjectsModelView 
                {
                    Budget = item.Budget,
                    Name = item.Name,
                    Id = item.Id,
                    Category = item.Category,
                    Services = item.Services,
                    Costs = item.Costs,
                }
            );
        }
        return projects;
    }
    public async Task<ProjectsModelView> CreateNewProject(ProjectsDTO projectDTO)
    {
        ProjectsEntity newProject = new ProjectsEntity 
        {
            Budget = projectDTO.Budget,
            Name = projectDTO.Name,
            Category_Id = projectDTO.Category.Id,
            Costs = projectDTO.Costs,
        };

        var projectCreated = _context.Projects.Add(newProject);
        await _context.SaveChangesAsync();

        var projectToReturn = await _context.Projects
        .Include(x => x.Services)
        .Where(x => x.Id == projectCreated.Entity.Id).FirstOrDefaultAsync();

        if (projectToReturn != null)
        {
            return new ProjectsModelView 
            {
                Id = projectToReturn.Id,
                Name = projectToReturn.Name,
                Budget = projectToReturn.Budget,
                Costs = projectToReturn.Costs,
                Category = projectToReturn.Category,
                Services = projectToReturn.Services
            };
        }
        return new ProjectsModelView();
    }

    public async Task<ProjectsModelView?> DeleteOneProject(int id)
    {
        var result = await _context.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (result != null)
        {
            ProjectsModelView project = new ProjectsModelView
            {
                Budget = result.Budget,
                Category = result.Category,
                Costs = result.Costs,
                Id = result.Id,
                Name = result.Name,
                Services = result.Services
            };

            _context.Projects.Remove(result);
            await _context.SaveChangesAsync();

            return project;
        }

        return null;
    }

    public async Task<ProjectsModelView?> GetById(int id)
    {
        var result = await _context.Projects.Where(x => x.Id == id)
        .Include(x => x.Category)
        .Include(x => x.Services)
        .FirstOrDefaultAsync();

        if (result != null)
        {
            ProjectsModelView project = new ProjectsModelView
            {
                Budget = result.Budget,
                Category = result.Category,
                Costs = result.Costs,
                Id = result.Id,
                Name = result.Name,
                Services = result.Services
            };
            return project;
        }
        return null;
    }

    public async Task<ProjectsModelView?> UpdateOneProject(int id, ProjectsDTO projectDTO)
    {
        var result = await _context.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (result != null)
        {
            result.Budget = projectDTO.Budget;
            result.Costs = projectDTO.Costs;
            result.Name = projectDTO.Name;
            result.Category_Id = projectDTO.Category.Id;

            _context.Projects.Update(result);
            await _context.SaveChangesAsync();

            return new ProjectsModelView 
            {
                Budget = projectDTO.Budget,
                Costs = projectDTO.Costs,
                Name = projectDTO.Name,
                Category = result.Category,
                Services = result.Services,
                Id = result.Id,
            };
        }
        return null;
    }

    public async Task AddOneService(int id, List<ProjectsServicesDTO> projectsServicesDTO)
    {
        ProjectServicesEntity service = new ProjectServicesEntity 
        {
            Cost = projectsServicesDTO[projectsServicesDTO.Count - 1].Cost,
            Description = projectsServicesDTO[projectsServicesDTO.Count - 1].Description,
            Project_Id = id,
            Name = projectsServicesDTO[projectsServicesDTO.Count - 1].Name,
        };
        _context.ProjectServices.Add(service);
        await _context.SaveChangesAsync();
    }

    public async Task<ProjectsServicesDTO?> DeleteOneService(int id)
    {
        var result = await _context.ProjectServices.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (result != null)
        {
            _context.ProjectServices.Remove(result);
            await _context.SaveChangesAsync();

            return new ProjectsServicesDTO 
            {
                Cost = result.Cost,
                Description = result.Description,
                Name = result.Name
            };
        }

        return null;
    }
}
