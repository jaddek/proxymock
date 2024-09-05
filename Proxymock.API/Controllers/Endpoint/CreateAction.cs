using Mapster;
using Microsoft.AspNetCore.Mvc;
using Proxymock.API.Domain.Project.Endpoint;
using Proxymock.API.Domain.Project.Endpoint.Request;
using Proxymock.API.Domain.Project.Project;

namespace Proxymock.API.Controllers.Endpoint;

[Route(("/api"))]
[ApiController]
public class CreateAction(
    EndpointRepository endpointRepository,
    ProjectRepository projectRepository
    ) : ControllerBase
{
    [HttpPost("project/{projectId}/endpoint")]
    public async Task<IActionResult> Invoke(Guid projectId, [FromBody] EndpointDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Entities.Project? project = await LoadProjectAsync(projectId);

        if (project is null)
        {
            return NotFound("Project not found");
        }

        Entities.Endpoint endpoint = request.Adapt<Entities.Endpoint>();
        endpoint.Project = project;
        await endpointRepository.CreateAsync(endpoint);

        return Ok(endpoint);
    }
    
    private async Task<Entities.Project?> LoadProjectAsync(Guid id)
    {
        Entities.Project? project = await projectRepository.FindOneAsync(id);

        return project;
    }
}