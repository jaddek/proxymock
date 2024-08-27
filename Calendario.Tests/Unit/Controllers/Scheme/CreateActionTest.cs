using Microsoft.AspNetCore.Mvc;
using Calendario.API.Controllers.Schema;

namespace Calendario.Tests.Unit.Controllers.Scheme
{
    public class CreateActionTest
    {

        private static CreateAction GetController()
        {
            return new();
        }

        [Theory]
        [InlineData("1d534d25-3c99-45cd-a022-7d9e7db15ebb")]
        public async Task CreateSchemeTest_Success(Guid id)
        {
            var result = await GetController().Invoke(id);

            Assert.IsAssignableFrom<ActionResult>(result);
        }
    }
}