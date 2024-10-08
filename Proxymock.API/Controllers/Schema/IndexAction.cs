using Microsoft.AspNetCore.Mvc;

namespace Proxymock.API.Controllers.Schema;

[Route(("/api"))]
[ApiController]
public class IndexAction() : ControllerBase
{
    [HttpPost("/schemes")]
    public async Task<IActionResult> Invoke()
    {
        await Task.Delay(100);

        return Ok();
    }
}