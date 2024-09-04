using Microsoft.AspNetCore.Mvc;

namespace Calendario.API.Controllers.Schema
{

    [Route(("/api"))]
    [ApiController]
    public class CreateAction() : ControllerBase
    {
        [HttpPost("/scheme/{schemeId}")]
        public async Task<IActionResult> Invoke(Guid schemeId)
        {
            await Task.Delay(100);

            return Ok();
        }
    }
}