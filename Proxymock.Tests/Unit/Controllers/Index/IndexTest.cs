using Proxymock.API.Controllers.Index;
using Microsoft.AspNetCore.Mvc;

namespace Proxymock.Tests.Unit.Controllers.Index
{
    public class IndexTest
    {
        private static IndexAction GetController()
        {
            return new();
        }

        [Fact]
        public async Task IndexTest_Successfull()
        {
            var result = await GetController().Index();

            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}