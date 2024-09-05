using Mapster;
using Microsoft.AspNetCore.Mvc;
using Proxymock.API.Domain.Project.Project;
using Proxymock.API.Domain.Project.Project.Request;

namespace Proxymock.API.Controllers.Project;

[Route(("/api"))]
[ApiController]
public class CreateAction(ProjectRepository repository) : ControllerBase
{
    [HttpPost("project")]
    public async Task<IActionResult> Invoke([FromBody] ProjectDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Entities.Project project = request.Adapt<Entities.Project>();
        await repository.CreateProject(project);

        return Ok(project);
    }
}