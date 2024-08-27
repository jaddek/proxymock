using Calendario.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Calendario.API.Domain.Project;
using PE = Calendario.API.Entities.Project;
using Calendario.API.Domain.Project.Request;
using Calendario.API.Controllers.Project;

namespace Calendario.Tests.Unit.Controllers.Project
{
    public class CreateActionTest
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

        private static CreateAction GetController()
        {
            return new(GetRepository());
        }

        [Theory]
        [InlineData("Created title 1")]
        [InlineData("Created title 2")]
        public async Task CreateProjectTest_Success(string title)
        {
            ProjectDTO projectDTO = new(title);

            var result = await GetController().Invoke(projectDTO);

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