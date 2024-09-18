using System.Text.Json;
using Proxymock.API.Domain;
using Proxymock.API.Domain.Unit;
using Spectre.Console.Cli;

namespace Proxymock.Console.Commands;

public class GenerateMockDataBySchemeCommand : Command<GenerateMockDataBySchemeCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "<path>")] public required string File { get; set; }
    }
    
    public override int Execute(CommandContext context, Settings settings)
    {

        var json = JsonDocument.Parse(File.ReadAllText(settings.File));
        var a = SchemaTransformer.TransformSchema(json);
        var b = ResponseGenerator.Run(a);



        var q = JsonSerializer.Serialize(b);
        var c = 1;

        return 0;
    }

}