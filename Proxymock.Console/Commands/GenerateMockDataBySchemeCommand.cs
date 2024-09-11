using Newtonsoft.Json.Linq;
using Proxymock.API.Domain.Unit;
using Spectre.Console;
using Spectre.Console.Cli;
using Range = Proxymock.API.Domain.Unit.Range;

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

        dynamic doc = JObject.Parse(jsonString);

        HandleJsonDocument(doc);

        return (int)CommandResponseEnum.ResultSuccess;
    }

    private static readonly Dictionary<string, Func<JToken, BaseUnit>> Dict = new()
    {
        { "id", HandleId },
        { "uuid", HandleUuid }
    };

    private static readonly Dictionary<string, BaseUnit> Dict2 = new();


    private static void HandleJsonDocument(dynamic doc)
    {
        foreach (string key in Dict.Keys)
        {
            Dict2[key] = Dict[key](doc[key]);
        }

        // var a = 1;
    }

    private static BaseUnit HandleId(JToken jToken)
    {
        Range range = new()
        {
            Min = int.Parse(jToken["range"]?["min"]?.ToString() ?? int.MinValue.ToString()),
            Max = int.Parse(jToken["range"]?["max"]?.ToString() ?? int.MaxValue.ToString())
        };

        return new Id
        {
            Type = jToken["type"]?.ToString() ?? string.Empty,
            Unsigned = bool.TryParse(jToken["unsigned"]?.ToString(), out _),
            Nullable = bool.TryParse(jToken["nullable"]?.ToString(), out _),
            Range = range,
        };
    }

    private static BaseUnit HandleUuid(JToken jToken)
    {
        return new Uuid
        {
            Type = jToken["type"]?.ToString() ?? string.Empty,
            Nullable = jToken.Value<bool>("nullable"),
        };
    }
}