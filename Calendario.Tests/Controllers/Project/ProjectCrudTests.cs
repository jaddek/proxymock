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
            Mock<ProjectRepository> mockPojectRepository = new(null!);
            mockPojectRepository.Setup(static m => m.FindProjects()).ReturnsAsync([]);

            return mockPojectRepository.Object;
        }

        private static IndexController GetController()
        {
            return new(GetRepository());
        }

        [Theory]
        [InlineData("test1")]
        [InlineData("ASdjkljkljsd")]
        public async Task IndexControllerCreateProjectTest(string title)
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

        [Fact]
        public async Task IndexControllerGetProjectsTest()
        {
            var result = await GetController().GetProjects();

            Assert.IsAssignableFrom<ActionResult<IEnumerable<PE>>>(result);
        }
    }
}