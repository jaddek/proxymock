using Microsoft.AspNetCore.Mvc;
using Moq;
using Proxymock.API.Controllers.Project;
using Proxymock.API.Domain.Project.Project;
using PE = Proxymock.API.Entities.Project;

namespace Proxymock.Tests.Unit.Controllers.Project
{
    public class ReadActionTest
    {
        private static ProjectRepository GetRepository()
        {
            PE project = new()
            {
                Title = "TestTitle"
            };

            Mock<ProjectRepository> mockProjectRepository = new(null!);
            mockProjectRepository.Setup(static m => m.FindOneAsync(It.IsAny<Guid>())).ReturnsAsync(project);

            return mockProjectRepository.Object;
        }

        private static ReadAction GetController()
        {
            return new(GetRepository());
        }

        [Theory]
        [InlineData("1d534d25-3c99-45cd-a022-7d9e7db15ebb")]
        public async Task GetProjectTest_Success(Guid id)
        {
            var result = await GetController().Invoke(id);

            Assert.IsAssignableFrom<IActionResult>(result);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as PE;
            Assert.NotNull(model);

            var actual = model.Title;
            Assert.Equal("TestTitle", actual);
        }
    }
}