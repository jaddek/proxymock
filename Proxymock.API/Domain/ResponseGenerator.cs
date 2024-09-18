using Proxymock.API.Domain.Unit;

namespace Proxymock.API.Domain;

public static class ResponseGenerator
{
    public static dynamic Run(Dictionary<string, BaseUnit> units)
    {
        var dict = new Dictionary<string, dynamic>();
        foreach (var unit in units)
        {
            var v = unit.Value;
            
            dict[unit.Key] = Runner2.ResolveGen(v);
        }

        return dict;
    }
}