using Microsoft.AspNetCore.Mvc;
using Moq;
using Proxymock.API.Controllers.Project;
using Proxymock.API.Domain.Project.Project;
using Proxymock.API.Domain.Project.Project.Request;
using PE = Proxymock.API.Entities.Project;

namespace Proxymock.Tests.Unit.Controllers.Project;

public class CreateActionTest
{
    private static ProjectRepository GetRepository()
    {
        PE project = new()
        {
            Title = "TestTitle"
        };

        Mock<ProjectRepository> mockPojectRepository = new(null!);
        mockPojectRepository.Setup(static m => m.FindOneAsync(It.IsAny<Guid>())).ReturnsAsync(project);

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
        ProjectDto projectDto = new(title);

        var result = await GetController().Invoke(projectDto);

        Assert.IsAssignableFrom<IActionResult>(result);

        var okObjectResult = result as OkObjectResult;
        Assert.NotNull(okObjectResult);

        var model = okObjectResult.Value as PE;
        Assert.NotNull(model);

        var actual = model.Title;
        Assert.Equal(title, actual);
    }
}