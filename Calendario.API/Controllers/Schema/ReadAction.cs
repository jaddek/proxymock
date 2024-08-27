using Microsoft.AspNetCore.Mvc;

namespace Calendario.API.Controllers.Schema
{

    [Route(("/api"))]
    [ApiController]
    public class ReadAction() : ControllerBase
    {
        [HttpGet("/schemas")]
        async public Task<IActionResult> Invoke(Guid schemeId)
        {
            await Task.Delay(100);

            return Ok();
        }
    }
}