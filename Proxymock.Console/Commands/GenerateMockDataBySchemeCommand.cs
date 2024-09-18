using Newtonsoft.Json.Linq;
using Proxymock.API.Domain.Project.Schema.Type.Newton;
using Proxymock.API.Domain.Unit;
using Spectre.Console;
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
        Dictionary<string, Type> dict = new()
        {
            { "id", typeof(Id) }
        };

        string path = Path.GetFullPath(settings.File);

        if (!File.Exists(path))
        {
            AnsiConsole.MarkupLine("[red]File does not exist![/]");
            return (int)CommandResponseEnum.ResultHasError;
        }

        string jsonString = File.ReadAllText(settings.File);

        var doc = JObject.Parse(jsonString);

        HandleJsonDocument(doc);

        return (int)CommandResponseEnum.ResultSuccess;
    }

    private static readonly Dictionary<string, Func<JToken, BaseUnit>> Dict = new()
    {
        { "id", HandleId },
        { "uuidV4", HandleUuid },
        { "title", HandleTitle }
    };

    private static readonly Dictionary<string, BaseUnit> Dict2 = new();


    private static void HandleJsonDocument(JObject doc)
    {
        foreach (var node in doc)
        {
            var parser = Dict[node.Value?["type"]?.ToString() ?? throw new Exception("Invalid JSON")];
            
            Dict2[node.Key] = parser(node.Value ?? throw new Exception("bla bla bla"));
        }
        var c = 1;
    }

    private static BaseUnit HandleTitle(JToken jToken)
    {
        return TitleFactory.BuildFromJson(jToken);
    }
    
    private static BaseUnit HandleId(JToken jToken)
    {
        return IdFactory.BuildFromJson(jToken);
    }

    private static BaseUnit HandleUuid(JToken jToken)
    {
        return UuidFactory.BuildFromJson(jToken);
    }
}