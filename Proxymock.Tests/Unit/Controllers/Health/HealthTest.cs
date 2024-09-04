using Proxymock.API.Controllers.Index;
using Microsoft.AspNetCore.Mvc;

namespace Proxymock.Tests.Unit.Controllers.Health
{

    public class IndexTests
    {
        private static HealthAction GetController()
        {
            return new();
        }

        [Fact]
        public async Task IndexControllerHealthTest()
        {
            var result = await GetController().Health();

            Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}