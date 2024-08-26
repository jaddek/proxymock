using Calendario.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Calendario.API.Domain.Project;

namespace Calendario.Tests.Controllers.Index;

public class IndexTests
{
    private static IndexController GetController()
    {
        return new();
    }

    [Fact]
    public async Task IndexControllerIndexTest()
    {
        var result = await GetController().Index();

        Assert.IsAssignableFrom<IActionResult>(result);
    }

    [Fact]
    public async Task IndexControllerHealthTest()
    {
        var result = await GetController().Health();

        Assert.IsAssignableFrom<IActionResult>(result);
    }

    [Fact]
    public async Task IndexControllerAttachSchemeToEndpointTest()
    {
        var result = await GetController().AttachSchemeToEndpoint(1, 2, 3);

        Assert.IsAssignableFrom<ActionResult>(result);
    }

    [Fact]
    public async Task IndexControllerAttachEndpointTest()
    {
        var result = await GetController().AttachEndpoint(1);

        Assert.IsAssignableFrom<IActionResult>(result);
    }

    [Fact]
    public async Task IndexControllerAttachSchedulerTest()
    {
        var result = await GetController().AttachScheduler(1, 2);

        Assert.IsAssignableFrom<IActionResult>(result);
    }

    [Fact]
    public async Task IndexControllerCreateSchedulerTest()
    {
        var result = await GetController().CreateScheduler(1);

        Assert.IsAssignableFrom<IActionResult>(result);
    }
}