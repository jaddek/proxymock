using Microsoft.AspNetCore.Mvc;
using Moq;
using Proxymock.API.Controllers.Project;
using Proxymock.API.Domain.Project.Project;
using PE = Proxymock.API.Entities.Project;

namespace Proxymock.Tests.Unit.Controllers.Project
{
    public class IndexActionTest
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