namespace Proxymock.API.Domain.Unit.Base;

public record Range()
{
    private const int DefaultMax = int.MaxValue;
    private const int DefaultMin = int.MinValue;

    public int Min { get; init; } = DefaultMin;
    public int Max { get; init; } = DefaultMax;
}