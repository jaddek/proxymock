using Mapster;
using Microsoft.AspNetCore.Mvc;
using Proxymock.API.Domain.Project.Project;
using Proxymock.API.Domain.Project.Project.Request;

namespace Proxymock.API.Controllers.Project;

[Route(("/api"))]
[ApiController]
public class UpdateAction(ProjectRepository repository) : ControllerBase
{
    [HttpPut("project/{id}")]
    public async Task<IActionResult> Invoke([FromBody] ProjectDto request, Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Entities.Project? project = await LoadProject(id);

        if (project is null)
        {
            return NotFound();
        }

        request.Adapt(project);
        await repository.UpdateProject(project);

        return Ok(project);
    }

    private async Task<Entities.Project?> LoadProject(Guid Id)
    {
        Entities.Project? project = await repository.FindOneAsync(Id);

        return project;
    }
}