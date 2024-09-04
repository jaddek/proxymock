using Microsoft.AspNetCore.Mvc;
using Proxymock.API.Domain.Project;

namespace Proxymock.API.Controllers.Project
{
    [Route(("/api"))]
    [ApiController]
    public class ReadAction(ProjectRepository repository) : ControllerBase
    {
        [HttpGet("project/{id}")]
        public async Task<IActionResult> Invoke(Guid id)
        {
            Entities.Project? Project = await LoadProject(id);

            if (Project is null)
            {
                return NotFound();
            }

            return Ok(Project);
        }

        private async Task<Entities.Project?> LoadProject(Guid Id)
        {
            Entities.Project? Project = await repository.FindProject(Id);

            return Project;
        }
    }
}