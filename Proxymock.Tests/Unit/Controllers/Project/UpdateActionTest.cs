using Microsoft.AspNetCore.Mvc;
using Moq;
using Proxymock.API.Controllers.Project;
using Proxymock.API.Domain.Project.Project;
using Proxymock.API.Domain.Project.Project.Request;
using PE = Proxymock.API.Entities.Project;

namespace Proxymock.Tests.Unit.Controllers.Project
{
    public class UpdateActionTest
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

        private static UpdateAction GetController()
        {
            return new(GetRepository());
        }

        [Theory]
        [InlineData("Updated title 1", "1d534d25-3c99-45cd-a022-7d9e7db15ebb")]
        [InlineData("Updated title 2", "1d534d25-3c99-45cd-a022-7d9e7db15ebc")]
        public async Task UpdateProjectTest_Success(string title, string id)
        {
            ProjectDto projectDto = new(title);

            var result = await GetController().Invoke(projectDto, Guid.Parse(id));

            Assert.IsAssignableFrom<IActionResult>(result);


            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as PE;
            Assert.NotNull(model);

            var actual = model.Title;
            Assert.Equal(title, actual);
        }
    }
}