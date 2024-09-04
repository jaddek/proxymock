using Microsoft.AspNetCore.Mvc;
using Moq;
using Proxymock.API.Domain.Project;
using PE = Proxymock.API.Entities.Project;
using Proxymock.API.Controllers.Project;

namespace Proxymock.Tests.Unit.Controllers.Project
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