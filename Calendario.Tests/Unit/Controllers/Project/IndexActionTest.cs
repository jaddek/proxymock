using Microsoft.AspNetCore.Mvc;
using Moq;
using Calendario.API.Domain.Project;
using PE = Calendario.API.Entities.Project;
using Calendario.API.Controllers.Project;

namespace Calendario.Tests.Unit.Controllers.Project
{
    public class IndexActionTest
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

        private static IndexAction GetController()
        {
            return new(GetRepository());
        }

        public static async Task GetProjectsTest_Success()
        {
            var result = await GetController().Invoke();

            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}