using Microsoft.AspNetCore.Mvc;

namespace Proxymock.API.Controllers.Index
{
    [Route(("/"))]
    [ApiController]
    public class IndexAction() : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            // throw new Excep
            await Task.Delay(100);

            return Ok();
        }
    }
}