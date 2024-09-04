using Microsoft.AspNetCore.Mvc;

namespace Calendario.API.Controllers.Schema
{

    [Route(("/api"))]
    [ApiController]
    public class DeleteAction() : ControllerBase
    {
        [HttpDelete("/scheme/{schemeId}")]
        public async Task<IActionResult> Invoke(Guid schemeId)
        {
            await Task.Delay(100);

            return NoContent();
        }
    }
}