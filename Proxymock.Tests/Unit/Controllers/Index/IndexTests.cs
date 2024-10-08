using Proxymock.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Proxymock.Tests.Unit.Controllers.Index
{

    public class IndexTests
    {
        private static IndexController GetController()
        {
            return new();
        }

        [Fact]
        public async Task IndexControllerAttachSchedulerTest()
        {
            var result = await GetController().AttachScheduler(1, 2);

            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public async Task IndexControllerCreateSchedulerTest()
        {
            var result = await GetController().CreateScheduler(1);

            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}