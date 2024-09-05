using Microsoft.AspNetCore.Mvc;
using Moq;
using Proxymock.API.Domain.Project.Endpoint;
using Proxymock.API.Domain.Project.Project;
using PE = Proxymock.API.Entities.Project;
using ReadAction = Proxymock.API.Controllers.Endpoint.ReadAction;

namespace Proxymock.Tests.Unit.Controllers.Endpoint;

public class ReadActionTest
{
    private static EndpointRepository GetEndpointRepository()
    {
        PE project = new()
        {
            Title = "TestTitle"
        };


        API.Entities.Endpoint endpoint = new()
        {
            Url = "TestUrl",
            Project = project,
        };
        
        Mock<EndpointRepository> mockEndpointRepo = new(null!);
        mockEndpointRepo.Setup(static m => m.FindProjectEndpoint(It.IsAny<PE>(), It.IsAny<Guid>())).ReturnsAsync(endpoint);

        return mockEndpointRepo.Object;
    }
    
    private static ProjectRepository GetProjectRepository()
    {
        PE project = new()
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
    [InlineData("1d534d25-3c99-45cd-a022-7d9e7db15ebb", "1d534d25-3c99-45cd-a022-7d9e7db15ebb")]
    public async Task GetProjectTest_Success(Guid projectId, Guid endpointId)
    {
        var result = await GetController().Invoke(projectId, endpointId);

        Assert.IsAssignableFrom<IActionResult>(result);

        var okObjectResult = result as OkObjectResult;
        Assert.NotNull(okObjectResult);

        var model = okObjectResult.Value as API.Entities.Endpoint;
        Assert.NotNull(model);
    }
}