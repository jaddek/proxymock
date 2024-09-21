using Bogus;
using Proxymock.API.Domain.Unit;

namespace Proxymock.API.Domain;

public class ResponseGenerator(Runner2 runner)
{
    public dynamic Run(Dictionary<string, BaseUnit?> units)
    {
        var dict = new Dictionary<string, dynamic?>();
        foreach (var unit in units)
        {
            dict[unit.Key] = unit.Value is null ? null : runner.ResolveGen(unit.Value);
        }

        return dict;
    }
}