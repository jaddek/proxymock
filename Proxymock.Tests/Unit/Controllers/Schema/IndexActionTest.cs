using Microsoft.AspNetCore.Mvc;
using Proxymock.API.Controllers.Schema;

namespace Proxymock.Tests.Unit.Controllers.Scheme
{
    public class IndexActionTest
    {

        private static IndexAction GetController()
        {
            return new();
        }

        [Fact]
        public async Task ReadSchemeTest_Success()
        {
            var result = await GetController().Invoke();

            Assert.IsAssignableFrom<ActionResult>(result);
        }
    }
}