using Newtonsoft.Json.Linq;
using Proxymock.API.Domain.Unit;
using Range = Proxymock.API.Domain.Unit.Range;

namespace Proxymock.API.Domain.Project.Schema.Type.Newton;

public static class UuidFactory
{
    public static Uuid BuildFromJson(JToken jToken)
    {
        var isNullable = false;
        var nullable = jToken["nullable"];

        if (nullable is { Type: JTokenType.Boolean } && nullable.Value<bool>())
        {
            isNullable = true;
        }

        return new Uuid
        {
            Type = typeof(Uuid).ToString(),
            Nullable = isNullable,
        };
    }
}