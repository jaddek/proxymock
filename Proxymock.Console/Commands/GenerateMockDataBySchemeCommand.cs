using System.Text.Json;
using Proxymock.API.Domain;
using Spectre.Console.Cli;

namespace Proxymock.Console.Commands;

public class GenerateMockDataBySchemeCommand(ResponseGenerator generator)
    : Command<GenerateMockDataBySchemeCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "<path>")] public required string File { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var json = JsonDocument.Parse(File.ReadAllText(settings.File));
        var dict = SchemaTransformer.TransformSchema(json);
        var response = generator.Run(dict);
        
        var jsonResponse = JsonSerializer.Serialize(response);
        
        System.Console.WriteLine(jsonResponse);
        
        return (int)CommandResponseEnum.ResultSuccess;
    }
}