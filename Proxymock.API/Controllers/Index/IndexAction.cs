using Microsoft.AspNetCore.Mvc;

namespace Proxymock.API.Controllers.Index
{
    [Route(("/api"))]
    [ApiController]
    public class IndexAction() : ControllerBase
    {
        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            await Task.Delay(100);

            return Ok();
        }
    }
}