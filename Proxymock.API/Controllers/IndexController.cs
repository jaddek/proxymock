using Microsoft.AspNetCore.Mvc;

namespace Proxymock.API.Controllers;

[Route(("/api"))]
[ApiController]
public class IndexController() : ControllerBase
{
    [HttpPost("project/{projectId}/scheduler/{schedulerId}")]
    public async Task<IActionResult> AttachScheduler(int projectId, int schedulerId)
    {
        await Task.Delay(100);

        return Ok();
    }

    [HttpPost("project/{projectId}/scheduler")]
    public async Task<IActionResult> CreateScheduler(int projectId)
    {
        await Task.Delay(100);

        return Ok();
    }
}