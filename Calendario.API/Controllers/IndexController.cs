using Calendario.API.Database;
using Calendario.API.Domain.Project;
using Calendario.API.Domain.Project.Request;
using Calendario.API.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Calendario.API.Controllers;

[Route(("/api"))]
[ApiController]
public class IndexController(ProjectRepository repository) : ControllerBase
{
    private readonly ProjectRepository _repository = repository;

    [HttpGet("/")]
    async public Task<IActionResult> Index()
    {
        await Task.Delay(100);

        return Ok();
    }

    [HttpGet("health")]
    async public Task<IActionResult> Health()
    {
        await Task.Delay(100);

        return Ok();
    }

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

    [HttpGet("projects")]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
    {
        return Ok(await _repository.FindProjects());
    }

    [HttpPost("project/{projectId}/endpoint/{endpointId}/scheme/{schemeId}")]
    async public Task<IActionResult> AttachSchemeToEndpoint(int projectId, int endpointId, int schemeId)
    {
        await Task.Delay(100);

        return Ok();
    }

    [HttpPost("project/{projectId}/endpoint")]
    async public Task<IActionResult> AttachEndpoint(int projectId)
    {
        await Task.Delay(100);

        return Ok();
    }

    [HttpPost("project/{projectId}/scheduler/{schedulerId}")]
    async public Task<IActionResult> AttachScheduler(int projectId, int schedulerId)
    {
        await Task.Delay(100);

        return Ok();
    }

    [HttpPost("project/{projectId}/scheduler")]
    async public Task<IActionResult> CreateScheduler(int projectId)
    {
        await Task.Delay(100);

        return Ok();
    }
}