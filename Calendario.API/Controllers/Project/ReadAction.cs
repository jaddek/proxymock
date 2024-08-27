using Calendario.API.Domain.Project;
using Microsoft.AspNetCore.Mvc;

namespace Calendario.API.Controllers.Project
{
    [Route(("/api"))]
    [ApiController]
    public class ReadAction(ProjectRepository repository) : ControllerBase
    {
        private readonly ProjectRepository _repository = repository;


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
            Entities.Project? Project = await _repository.FindProject(Id);

            return Project;
        }
    }
}