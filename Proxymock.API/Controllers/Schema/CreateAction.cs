using Mapster;
using Microsoft.AspNetCore.Mvc;
using Proxymock.API.Domain.Project.Endpoint;
using Proxymock.API.Domain.Project.Project;
using Proxymock.API.Domain.Project.Schema.Request;
using Proxymock.API.Domain.Project.Schema;

namespace Proxymock.API.Controllers.Schema;

[Route(("/api"))]
[ApiController]
public class CreateAction(
    ProjectRepository projectRepository,
    EndpointRepository endpointRepository,
    SchemaRepository schemaRepository
    ) : ControllerBase
{
    [HttpPost("project/{projectId}/endpoint/{endpointId}/schema")]
    public async Task<IActionResult> Invoke(
        Guid projectId, 
        Guid endpointId, 
        [FromBody] SchemaDto request
        )
    {
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

        Entities.Schema schema = request.Adapt<Entities.Schema>();
        schema.Endpoint = endpoint;
        await schemaRepository.CreateAsync(schema);

        return Ok(schema);
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

    private async Task<Entities.Schema?> LoadSchemeAsync(Guid id, Entities.Endpoint endpoint)
    {
        Entities.Schema? scheme = await schemaRepository.FindEndpointSchema(endpoint, id);

        return scheme;
    }
}