using Mapster;
using Microsoft.AspNetCore.Mvc;
using Proxymock.API.Domain.Project.Endpoint;
using Proxymock.API.Domain.Project.Endpoint.Request;
using Proxymock.API.Domain.Project.Project;
using Proxymock.API.Domain.Project.Project.Request;

namespace Proxymock.API.Controllers.Endpoint;

[Route(("/api"))]
[ApiController]
public class UpdateAction(
    EndpointRepository endpointRepository,
    ProjectRepository projectRepository
    ) : ControllerBase
{
    [HttpPut("project/{projectId}/endpoint/{endpointId}")]
    public async Task<IActionResult> Invoke(
        Guid projectId, 
        Guid endpointId,
        [FromBody] EndpointDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Entities.Project? project = await LoadProjectAsync(projectId);

        if (project is null)
        {
            return NotFound();
        }
        
        Entities.Endpoint? endpoint = await LoadEndpointAsync(endpointId, project);

        if (endpoint is null)
        {
            return NotFound();
        }

        request.Adapt(endpoint);
        await endpointRepository.UpdateAsync(endpoint);

        return Ok(endpoint);
    }

    private async Task<Entities.Project?> LoadProjectAsync(Guid id)
    {
        Entities.Project? project = await projectRepository.FindOneAsync(id);

        return project;
    }
    
    private async Task<Entities.Endpoint?> LoadEndpointAsync(Guid id, Entities.Project project)
    {
        Entities.Endpoint? endpoint = await endpointRepository.FindProjectEndpoint(project, id);

        return endpoint;
    }
}
