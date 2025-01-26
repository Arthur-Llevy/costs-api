using Api.Domain.DTOs;
using Api.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/projects")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectsInterface _projectsServices;
    public ProjectsController(ProjectsInterface projectsServices)
    {
        _projectsServices = projectsServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try 
        {
            var result = await _projectsServices.GetAll();
            return Ok(result);
        } catch (Exception ex)
        {
            throw new Exception($"Algo deu errado buscar os projetos: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try 
        {
            var result = await _projectsServices.GetById(id);
            return Ok(result);
        } catch (Exception ex)
        {
            throw new Exception($"Algo deu errado buscar os projetos: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProjectsDTO projectsDTO)
    {
        try 
        {
            var result = await _projectsServices.CreateNewProject(projectsDTO);
            return Created($"/projects/${result.Id}", result);
        } catch (Exception ex)
        {
            throw new Exception($"Algo deu errado ao criar um novo projeto: {ex.Message}");
        }
    }

    [HttpPatch("/projects/addService/{id}")]
    public async Task<IActionResult> CreateService(int id, List<ProjectsServicesDTO> projectsServicesDTO)
    {
        try 
        {
            await _projectsServices.AddOneService(id, projectsServicesDTO);
            return Ok();
        } catch (Exception ex)
        {
            throw new Exception($"Algo deu errado criar o serviço: {ex.Message}");
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> EditProject(int id, ProjectsDTO projectDTO)
    {
        try 
        {
            var result = await _projectsServices.UpdateOneProject(id, projectDTO);

            if (result != null)
            {
                return NoContent();
            } 
            return NotFound();
        } catch (Exception ex)
        {
            throw new Exception($"Algo deu errado tentar atualizar o projeto: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        try 
        {
            var result = await _projectsServices.DeleteOneProject(id);

            if (result != null)
            {
                return NoContent();
            } 
            return NotFound();
        } catch (Exception ex)
        {
            throw new Exception($"Algo deu errado ao tentar excluir o projeto: {ex.Message}");
        }
    }

    [HttpDelete("/projects/removeService/{id}")]
    public async Task<IActionResult> DeleteProjectService(int id)
    {
        try 
        {
            var result = await _projectsServices.DeleteOneService(id);

            if (result != null)
            {
                return NoContent();
            } 
            return NotFound();
        } catch (Exception ex)
        {
            throw new Exception($"Algo deu errado ao tentar excluir o serviço: {ex.Message}");
        }
    }
}