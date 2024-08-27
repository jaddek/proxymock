using Microsoft.AspNetCore.Mvc;

namespace Calendario.API.Controllers.Index;

[Route(("/api"))]
[ApiController]
public class HealthAction() : ControllerBase
{
    [HttpGet("health")]
    async public Task<IActionResult> Health()
    {
        await Task.Delay(100);

        return Ok();
    }
}