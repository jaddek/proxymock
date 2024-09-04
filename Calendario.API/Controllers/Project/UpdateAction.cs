using Calendario.API.Domain.Project;
using Calendario.API.Domain.Project.Request;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Calendario.API.Controllers.Project
{
    [Route(("/api"))]
    [ApiController]
    public class UpdateAction(ProjectRepository repository) : ControllerBase
    {
        [HttpPut("project/{id}")]
        public async Task<IActionResult> Invoke([FromBody] ProjectDTO request, Guid id)
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
            Entities.Project? project = await repository.FindProject(Id);

            return project;
        }
    }
}