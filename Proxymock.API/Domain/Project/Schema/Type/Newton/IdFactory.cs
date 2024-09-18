using Newtonsoft.Json.Linq;
using Proxymock.API.Domain.Unit;
using Range = Proxymock.API.Domain.Unit.Range;

namespace Proxymock.API.Domain.Project.Schema.Type.Newton;

public static class IdFactory
{
    public static Id BuildFromJson(JToken jToken)
    {
        bool isNullable = false;
        var nullable = jToken["nullable"];

        if (nullable is { Type: JTokenType.Boolean } && nullable.Value<bool>())
        {
            isNullable = true;
        }

        bool isUnsigned = false;
        var unsigned = jToken["unsigned"];

        if (unsigned is { Type: JTokenType.Boolean } && unsigned.Value<bool>())
        {
            isUnsigned = true;
        }

        var min = isUnsigned ? 0 : int.MinValue;
        var max = int.MaxValue;

        var tokenRangeValue = jToken["range"];
        if (tokenRangeValue is { Type: JTokenType.Object })
        {
            if (tokenRangeValue["max"] is { Type: JTokenType.Integer })
            {
                max = (tokenRangeValue["max"] ?? throw new InvalidOperationException()).Value<int>();
            }

            if (tokenRangeValue["min"] is { Type: JTokenType.Integer })
            {
                min = (tokenRangeValue["min"] ?? throw new InvalidOperationException()).Value<int>();
            }
        }

        Range range = new()
        {
            Min = min,
            Max = max
        };

        return new Id
        {
            Type = typeof(Id).ToString(),
            Unsigned = isUnsigned,
            Nullable = isNullable,
            Range = range,
        };
    }
}