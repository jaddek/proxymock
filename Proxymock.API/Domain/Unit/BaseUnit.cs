namespace Proxymock.API.Domain.Unit;

public abstract record BaseUnit
{
    public string Type { get; init; } = TypesEnum.Int.ToString();
}