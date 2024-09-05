using Microsoft.AspNetCore.Mvc;
using Proxymock.API.Domain.Project.Project;

namespace Proxymock.API.Controllers.Project;

[Route(("/api"))]
[ApiController]
public class ReadAction(ProjectRepository repository) : ControllerBase
{
    [HttpGet("project/{id}")]
    public async Task<IActionResult> Invoke(Guid id)
    {
        Entities.Project? project = await LoadProject(id);

        if (project is null)
        {
            return NotFound();
        }

        return Ok(project);
    }

    private async Task<Entities.Project?> LoadProject(Guid id)
    {
        Entities.Project? project = await repository.FindOneAsync(id);

        return project;
    }
}