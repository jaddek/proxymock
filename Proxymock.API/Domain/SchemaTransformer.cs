using System.Text.Json;
using Proxymock.API.Domain.Unit;

namespace Proxymock.API.Domain;

public static class SchemaTransformer
{
    public static Dictionary<string, BaseUnit> TransformSchema(JsonDocument jsonDocument)
    {
        JsonSerializerOptions? options = new()
        {
            PropertyNameCaseInsensitive= true,
        };

        Dictionary<string, BaseUnit> mirror = new();
        
        foreach (var firstLevelProperty in jsonDocument.RootElement.EnumerateObject())
        {
            var key = firstLevelProperty.Name;
            var type = firstLevelProperty.Value.GetProperty("type").ToString();
            var unit = Handle(type, firstLevelProperty, options);

            if (unit is null)
            {
                continue;
            }

            mirror[key] = unit;
        }

        return mirror;
    }
    
    private static BaseUnit? Handle(string key, JsonProperty property, JsonSerializerOptions? options)
    {
        var json = property.Value.GetProperty("attrs").GetRawText();
        return key switch
        {
            "id" => JsonSerializer.Deserialize<Id>(json, options),
            "uuidV4" => JsonSerializer.Deserialize<Uuid>(json, options),
            "title" => JsonSerializer.Deserialize<Title>(json, options),
            _ => null
        };
    }
}