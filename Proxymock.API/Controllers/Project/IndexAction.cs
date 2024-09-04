using Microsoft.AspNetCore.Mvc;
using Proxymock.API.Domain.Project;

namespace Proxymock.API.Controllers.Project
{

    [Route(("/api"))]
    [ApiController]
    public class IndexAction(ProjectRepository repository) : ControllerBase
    {
        [HttpGet("projects")]
        public async Task<ActionResult<IEnumerable<Entities.Project>>> Invoke()
        {
            return Ok(await repository.FindProjects());
        }
    }
}