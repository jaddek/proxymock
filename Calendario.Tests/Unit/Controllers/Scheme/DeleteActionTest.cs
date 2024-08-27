using Microsoft.AspNetCore.Mvc;
using Calendario.API.Controllers.Schema;

namespace Calendario.Tests.Unit.Controllers.Scheme
{
    public class DeleteActionTest
    {

        private static DeleteAction GetController()
        {
            return new();
        }

        [Theory]
        [InlineData("1d534d25-3c99-45cd-a022-7d9e7db15ebb")]
        public async Task DeleteSchemeTest_Success(Guid id)
        {
            var result = await GetController().Invoke(id);

            Assert.IsAssignableFrom<ActionResult>(result);
        }
    }
}