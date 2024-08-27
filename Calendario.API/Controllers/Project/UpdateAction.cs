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
        private readonly ProjectRepository _repository = repository;

        [HttpPut("project/{id}")]
        public async Task<IActionResult> Invoke([FromBody] ProjectDTO request, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Entities.Project? Project = await LoadProject(id);

            if (Project is null)
            {
                return NotFound();
            }

            request.Adapt(Project);
            await _repository.UpdateProject(Project);

            return Ok(Project);
        }

        private async Task<Entities.Project?> LoadProject(Guid Id)
        {
            Entities.Project? Project = await _repository.FindProject(Id);

            return Project;
        }
    }
}