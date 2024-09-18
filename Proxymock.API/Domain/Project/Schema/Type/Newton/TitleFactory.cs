using Newtonsoft.Json.Linq;
using Proxymock.API.Domain.Unit;
using Range = Proxymock.API.Domain.Unit.Range;

namespace Proxymock.API.Domain.Project.Schema.Type.Newton;

public static class TitleFactory
{
    public static Title BuildFromJson(JToken jToken)
    {
        bool isNullable = false;
        var nullable = jToken["nullable"];

        if (nullable is { Type: JTokenType.Boolean } && nullable.Value<bool>())
        {
            isNullable = true;
        }

        int defaultLength = 255;
        var length = jToken["length"];

        if (length is { Type: JTokenType.Integer })
        {
            defaultLength = length.Value<int>();
        }

        return new Title
        {
            Type = typeof(Title).ToString(),
            Nullable = isNullable,
            Length = defaultLength
        };
    }
}