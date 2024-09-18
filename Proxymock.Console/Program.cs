using Microsoft.Extensions.DependencyInjection;
using Proxymock.Console;
using Proxymock.Console.Commands;
using Spectre.Console.Cli;


IServiceCollection services = new ServiceCollection();
var registrar = new TypeRegistrar(services);

var app = new CommandApp(registrar);
app.Configure(config =>
{
    config.AddCommand<GenerateMockDataBySchemeCommand>("mock:generate:data");
    config.AddCommand<RouterDebugCommand>("router:debug");
});

app.Run(args);