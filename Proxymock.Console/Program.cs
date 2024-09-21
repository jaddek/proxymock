using Microsoft.Extensions.DependencyInjection;
using Proxymock.API.Domain;
using Proxymock.Console;
using Proxymock.Console.Commands;
using Spectre.Console;
using Spectre.Console.Cli;


IServiceCollection services = new ServiceCollection();
services.AddSingleton<Runner2>();
services.AddSingleton<ResponseGenerator>();

var registrar = new TypeRegistrar(services);

var app = new CommandApp(registrar);
app.Configure(config =>
{
#if DEBUG
    config.PropagateExceptions();
    config.ValidateExamples();
#endif
    config.AddCommand<GenerateMockDataBySchemeCommand>("mock:generate:data");
    config.AddCommand<RouterDebugCommand>("router:debug");
});
try
{
    await app.RunAsync(args);
}
catch (Exception e)
{
    AnsiConsole.WriteException(e);
}