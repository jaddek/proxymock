using Calendario.API.Domain.Project;
using Calendario.API.Domain.Project.Request;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Calendario.API.Controllers.Project
{

    [Route(("/api"))]
    [ApiController]
    public class CreateAction(ProjectRepository repository) : ControllerBase
    {
        private readonly ProjectRepository _repository = repository;


        [HttpPost("project")]
        public async Task<IActionResult> Invoke([FromBody] ProjectDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Entities.Project project = request.Adapt<Entities.Project>();
            await _repository.CreateProject(project);

            return Ok(project);
        }
    }
}