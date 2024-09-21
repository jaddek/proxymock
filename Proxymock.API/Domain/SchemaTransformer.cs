using System.Text.Json;
using Proxymock.API.Domain.Unit;
using Proxymock.API.Domain.Unit.Address;

namespace Proxymock.API.Domain;

public static class SchemaTransformer
{
    public static Dictionary<string, BaseUnit?> TransformSchema(JsonDocument jsonDocument)
    {
        JsonSerializerOptions? options = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        Dictionary<string, BaseUnit?> mirror = new();

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
            "Id" => JsonSerializer.Deserialize<Id>(json, options),
            "UuidV4" => JsonSerializer.Deserialize<Uuid>(json, options),
            "Title" => JsonSerializer.Deserialize<Title>(json, options),
            "ZipCode" => JsonSerializer.Deserialize<ZipCode>(json, options),
            "City" => JsonSerializer.Deserialize<City>(json, options),
            "StreetAddress" => JsonSerializer.Deserialize<StreetAddress>(json, options),
            "CityPrefix" => JsonSerializer.Deserialize<Unit.Unit>(json, options),
            "CitySuffix" => JsonSerializer.Deserialize<Unit.Unit>(json, options),
            "StreetName" => JsonSerializer.Deserialize<StreetName>(json, options),
            "BuildingNumber" => JsonSerializer.Deserialize<BuildingNumber>(json, options),
            "StreetSuffix" => JsonSerializer.Deserialize<Unit.Unit>(json, options),
            "SecondaryAddress" => JsonSerializer.Deserialize<Unit.Unit>(json, options),
            "County" => JsonSerializer.Deserialize<Unit.Unit>(json, options),
            "Country" => JsonSerializer.Deserialize<Country>(json, options),
            "FullAddress" => JsonSerializer.Deserialize<Unit.Unit>(json, options),
            "CountryCode" => JsonSerializer.Deserialize<Unit.Unit>(json, options),
            "State" => JsonSerializer.Deserialize<Unit.Unit>(json, options),
            "StateAbbr" => JsonSerializer.Deserialize<Unit.Unit>(json, options),
            "Latitude" => JsonSerializer.Deserialize<Unit.Unit>(json, options),
            "Longitude" => JsonSerializer.Deserialize<Unit.Unit>(json, options),
            "Direction" => JsonSerializer.Deserialize<Unit.Unit>(json, options),
            "CardinalDirection" => JsonSerializer.Deserialize<Unit.Unit>(json, options),
            "OrdinalDirection" => JsonSerializer.Deserialize<Unit.Unit>(json, options),
            _ => null
        };
    }
}