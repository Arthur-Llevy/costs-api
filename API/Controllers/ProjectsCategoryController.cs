using Api.Domain.DTOs;
using Api.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/categories")]
public class ProjectsCategoryController : ControllerBase
{
    private readonly ProjectsCategoryInterface _projectsCategoryServices;
    public ProjectsCategoryController(ProjectsCategoryInterface projectsCategoryServices)
    {
        _projectsCategoryServices = projectsCategoryServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try 
        {
            var result = await _projectsCategoryServices.GetAll();
            return Ok(result);
        } catch (Exception ex)
        {
            throw new Exception($"Algo deu errado buscar as categorias: {ex.Message}");
        }
    }

}