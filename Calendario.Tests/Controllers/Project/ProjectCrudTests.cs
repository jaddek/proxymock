using Calendario.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Calendario.API.Domain.Project;
using Calendario.API.Domain.Project.Request;
using PE = Calendario.API.Entities.Project;

namespace Calendario.Tests.Controllers.Project
{
    public class ProjectCrudTests
    {
        private static ProjectRepository GetRepository()
        {
            PE Project = new()
            {
                Title = "TestTitle"
            };

            Mock<ProjectRepository> mockPojectRepository = new(null!);
            mockPojectRepository.Setup(static m => m.FindProject(It.IsAny<Guid>())).ReturnsAsync(Project);
            mockPojectRepository.Setup(static m => m.FindProjects()).ReturnsAsync([]);

            return mockPojectRepository.Object;
        }

        private static ProjectController GetController()
        {
            return new(GetRepository());
        }

        [Theory]
        [InlineData("1d534d25-3c99-45cd-a022-7d9e7db15ebb")]
        public async Task GetProjectTest_Success(Guid id)
        {
            var result = await GetController().GetProject(id);

            Assert.IsAssignableFrom<IActionResult>(result);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as PE;
            Assert.NotNull(model);

            var actual = model.Title;
            Assert.Equal("TestTitle", actual);
        }

        [Theory]
        [InlineData("Created title 1")]
        [InlineData("Created title 2")]
        public async Task CreateProjectTest_Success(string title)
        {
            ProjectDTO projectDTO = new(title);

            var result = await GetController().CreateProject(projectDTO);

            Assert.IsAssignableFrom<IActionResult>(result);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as PE;
            Assert.NotNull(model);

            var actual = model.Title;
            Assert.Equal(title, actual);
        }

        [Theory]
        [InlineData("Updated title 1", "1d534d25-3c99-45cd-a022-7d9e7db15ebb")]
        [InlineData("Updated title 2", "1d534d25-3c99-45cd-a022-7d9e7db15ebc")]
        public async Task UpdateProjectTest_Success(string title, string id)
        {
            ProjectDTO projectDTO = new(title);

            var result = await GetController().UpdateProject(projectDTO, Guid.Parse(id));

            Assert.IsAssignableFrom<IActionResult>(result);


            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as PE;
            Assert.NotNull(model);

            var actual = model.Title;
            Assert.Equal(title, actual);
        }

        [Fact]
        public async Task IndexControllerGetProjectsTest()
        {
            var result = await GetController().GetProjects();

            Assert.IsAssignableFrom<ActionResult<IEnumerable<PE>>>(result);
        }
    }
}