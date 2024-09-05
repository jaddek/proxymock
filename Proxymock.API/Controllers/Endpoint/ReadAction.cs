using Microsoft.AspNetCore.Mvc;
using Proxymock.API.Domain.Project.Endpoint;
using Proxymock.API.Domain.Project.Project;

namespace Proxymock.API.Controllers.Endpoint;

[Route(("/api"))]
[ApiController]
public class ReadAction(
    EndpointRepository endpointRepository,
    ProjectRepository projectRepository
) : ControllerBase
{
    [HttpGet("project/{projectId}/endpoint/{endpointId}")]
    public async Task<IActionResult> Invoke(Guid projectId, Guid endpointId)
    {
        Entities.Project? project = await LoadProjectAsync(projectId);

        if (project is null)
        {
            return NotFound("Project not found");
        }

        Entities.Endpoint? endpoint = await LoadEndpointAsync(endpointId, project);
        
        if (endpoint is null)
        {
            return NotFound("Endpoint not found");
        }
        
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