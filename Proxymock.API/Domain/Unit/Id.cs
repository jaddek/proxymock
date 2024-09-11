namespace Proxymock.API.Domain.Unit;

public record Id(
    ): BaseUnit
{
    public  bool Unsigned { get; init; }
    public  bool Nullable { get; init; }
    public Range Range { get; init; }
}