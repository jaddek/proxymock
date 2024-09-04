using Microsoft.AspNetCore.Mvc;
using Moq;
using Proxymock.API.Domain.Project;
using PE = Proxymock.API.Entities.Project;
using Proxymock.API.Domain.Project.Request;
using Proxymock.API.Controllers.Project;

namespace Proxymock.Tests.Unit.Controllers.Project
{
    public class UpdateActionTest
    {
        private static ProjectRepository GetRepository()
        {
            PE Project = new()
            {
                Title = "TestTitle"
            };

            Mock<ProjectRepository> mockPojectRepository = new(null!);
            mockPojectRepository.Setup(static m => m.FindProject(It.IsAny<Guid>())).ReturnsAsync(Project);

            return mockPojectRepository.Object;
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
            ProjectDTO projectDTO = new(title);

            var result = await GetController().Invoke(projectDTO, Guid.Parse(id));

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