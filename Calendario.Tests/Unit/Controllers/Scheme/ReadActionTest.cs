using Microsoft.AspNetCore.Mvc;
using Calendario.API.Controllers.Schema;

namespace Calendario.Tests.Unit.Controllers.Scheme
{
    public class ReadActionTest
    {

        private static ReadAction GetController()
        {
            return new();
        }

        [Theory]
        [InlineData("1d534d25-3c99-45cd-a022-7d9e7db15ebb")]
        public async Task GetSchemeTest_Success(Guid id)
        {
            var result = await GetController().Invoke(id);

            Assert.IsAssignableFrom<ActionResult>(result);
        }
    }
}