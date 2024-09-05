using Microsoft.AspNetCore.Mvc;
using Moq;
using Proxymock.API.Controllers.Endpoint;
using Proxymock.API.Domain.Project.Endpoint;
using Proxymock.API.Domain.Project.Endpoint.Request;
using Proxymock.API.Domain.Project.Project;

namespace Proxymock.Tests.Unit.Controllers.Endpoint
{
    public class UpdateActionTest
    {
        private static EndpointRepository GetEndpointRepository()
        {
            API.Entities.Project project = new()
            {
                Title = "TestTitle"
            };


            API.Entities.Endpoint endpoint = new()
            {
                Url = "TestUrl",
                Project = project,
            };
        
            Mock<EndpointRepository> mockEndpointRepo = new(null!);
            mockEndpointRepo.Setup(static m => m.FindProjectEndpoint(It.IsAny<API.Entities.Project>(), It.IsAny<Guid>())).ReturnsAsync(endpoint);

            return mockEndpointRepo.Object;
        }
    
        private static ProjectRepository GetProjectRepository()
        {
            API.Entities.Project project = new()
            {
                Title = "TestTitle"
            };

            Mock<ProjectRepository> mockProjectRepository = new(null!);
            mockProjectRepository.Setup(static m => m.FindOneAsync(It.IsAny<Guid>())).ReturnsAsync(project);

            return mockProjectRepository.Object;
        }

        private static UpdateAction GetController()
        {
            ProjectRepository projectRepository = GetProjectRepository();
            EndpointRepository endpointRepository = GetEndpointRepository();
        
            return new(endpointRepository, projectRepository);
        }

        [Theory]
        [InlineData("1d534d25-3c99-45cd-a022-7d9e7db15ebb", "1d534d25-3c99-45cd-a022-7d9e7db15ebb", "Random url 3")]
        public async Task UpdateProjectTest_Success(Guid projectId, Guid endpointId, string url)
        {
            EndpointDto endpointDto = new(url);

            var result = await GetController().Invoke(projectId,endpointId, endpointDto);

            Assert.IsAssignableFrom<IActionResult>(result);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as API.Entities.Endpoint;
            Assert.NotNull(model);
        }
    }
}