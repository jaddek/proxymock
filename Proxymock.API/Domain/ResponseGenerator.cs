namespace Proxymock.API.Domain;

public class ResponseGenerator(Runner runner)
{
    public dynamic Run(Dictionary<string, Unit.Unit?> units)
    {
        var dict = new Dictionary<string, dynamic?>();
        foreach (var unit in units)
        {
            dict[unit.Key] = unit.Value is null ? null : runner.ResolveGen(unit.Value);
        }

        return dict;
    }
}