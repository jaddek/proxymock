using Calendario.API.Domain.Project;
using Calendario.API.Domain.Project.Request;
using Calendario.API.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Calendario.API.Controllers;

[Route(("/api"))]
[ApiController]
public class ProjectController(ProjectRepository repository) : ControllerBase
{
    private readonly ProjectRepository _repository = repository;


    [HttpPost("project")]
    public async Task<IActionResult> CreateProject([FromBody] ProjectDTO request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Project project = request.Adapt<Project>();
        await _repository.CreateProject(project);

        return Ok(project);
    }

    [HttpPut("project/{id}")]
    public async Task<IActionResult> UpdateProject([FromBody] ProjectDTO request, Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Project? Project = await LoadProject(id);

        if (Project is null)
        {
            return NotFound();
        }

        request.Adapt(Project);
        await _repository.UpdateProject(Project);

        return Ok(Project);
    }

    [HttpGet("project/{id}")]
    public async Task<IActionResult> GetProject(Guid id)
    {
        Project? Project = await LoadProject(id);

        if (Project is null)
        {
            return NotFound();
        }

        return Ok(Project);
    }

    [HttpGet("projects")]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
    {
        return Ok(await _repository.FindProjects());
    }

    private async Task<Project?> LoadProject(Guid Id)
    {
        Project? Project = await _repository.FindProject(Id);

        return Project;
    }
}