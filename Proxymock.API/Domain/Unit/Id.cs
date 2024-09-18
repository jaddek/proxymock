namespace Proxymock.API.Domain.Unit;

public record Id(
) : BaseUnit
{
    private readonly bool _unsigned = true;

    public dynamic Unsigned
    {
        get => _unsigned;
        init => bool.TryParse(value.ToString(), out _unsigned);
    }

    public bool Nullable { get; init; }
    public Range Range { get; init; } = new();
}