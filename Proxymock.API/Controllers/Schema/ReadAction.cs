using Microsoft.AspNetCore.Mvc;

namespace Proxymock.API.Controllers.Schema;

[Route(("/api"))]
[ApiController]
public class ReadAction() : ControllerBase
{
    [HttpGet("/schemas")]
    public async Task<IActionResult> Invoke(Guid schemeId)
    {
        await Task.Delay(100);

        return Ok();
    }
}