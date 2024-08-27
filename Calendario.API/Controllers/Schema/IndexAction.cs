using Microsoft.AspNetCore.Mvc;

namespace Calendario.API.Controllers.Schema
{

    [Route(("/api"))]
    [ApiController]
    public class IndexAction() : ControllerBase
    {
        [HttpPost("/schemes")]
        async public Task<IActionResult> Invoke()
        {
            await Task.Delay(100);

            return Ok();
        }
    }
}