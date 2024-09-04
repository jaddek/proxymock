using Calendario.API.Domain.Project;
using Microsoft.AspNetCore.Mvc;

namespace Calendario.API.Controllers.Project
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