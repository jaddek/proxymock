using Calendario.API.Database;
using Calendario.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Calendario.API.Controllers;

[Route(("api"))]
public class IndexController(ILogger<IndexController> _logger) : ControllerBase
{
    private readonly DBContext dbContext;

    [HttpGet("/")]
    public IActionResult Index()
    {
        return Ok();
    }

    [HttpPost("project")]
    public ActionResult CreateProject()
    {
        return Ok();
    }
    [HttpGet("project")]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
    {
        return await dbContext.Projects.ToListAsync();

    }

    [HttpPost("project/{projectId}/endpoint/{endpointId}/scheme/{schemeId}")]
    public ActionResult AttachSchemeToEndpoint(int projectId, int endpointId, int schemeId)
    {
        return Ok();
    }

    [HttpPost("project/{projectId}/endpoint")]
    public ActionResult AttachEndpoint(int projectId)
    {
        return Ok();
    }

    [HttpPost("project/{projectId}/scheduler/{schedulerId}")]
    public ActionResult AttachScheduler(int projectId, int schedulerId)
    {
        return Ok();
    }

    [HttpPost("project/{projectId}/scheduler")]
    public ActionResult CreateScheduler(int projectId)
    {
        return Ok();
    }
}