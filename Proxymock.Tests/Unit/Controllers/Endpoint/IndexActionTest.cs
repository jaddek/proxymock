using Microsoft.AspNetCore.Mvc;
using Moq;
using Proxymock.API.Controllers.Endpoint;
using Proxymock.API.Domain.Project.Endpoint;
using Proxymock.API.Domain.Project.Project;

namespace Proxymock.Tests.Unit.Controllers.Endpoint;

public class IndexActionTest
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
    
    private static ReadAction GetController()
    {
        ProjectRepository projectRepository = GetProjectRepository();
        EndpointRepository endpointRepository = GetEndpointRepository();
        
        return new(endpointRepository, projectRepository);
    }

    [Theory]
    [InlineData("1d534d25-3c99-45cd-a022-7d9e7db15ebb","1d534d25-3c99-45cd-a022-7d9e7db15ebb")]
    public static async Task GetEndpointsTest_Success(Guid projectId, Guid endpointId)
    {
        var result = await GetController().Invoke(projectId, endpointId);

        Assert.IsAssignableFrom<IActionResult>(result);
    }
}