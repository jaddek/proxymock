using Microsoft.AspNetCore.Mvc;
using Proxymock.API.Controllers.Schema;

namespace Proxymock.Tests.Unit.Controllers.Scheme
{
    public class UpdateActionTest
    {

        private static UpdateAction GetController()
        {
            return new();
        }

        [Theory]
        [InlineData("1d534d25-3c99-45cd-a022-7d9e7db15ebb")]
        public async Task UpdateSchemeTest_Success(Guid id)
        {
            var result = await GetController().Invoke(id);

            Assert.IsAssignableFrom<ActionResult>(result);
        }
    }
}