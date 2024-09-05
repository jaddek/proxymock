using Microsoft.AspNetCore.Mvc;

namespace Proxymock.API.Controllers.Index;

[Route(("/api"))]
[ApiController]
public class HealthAction() : ControllerBase
{
    [HttpGet("health")]
    public async Task<IActionResult> Health()
    {
        await Task.Delay(100);

        return Ok();
    }
}