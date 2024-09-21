namespace Proxymock.API.Domain.Unit.Base;

public record Id : Unit
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