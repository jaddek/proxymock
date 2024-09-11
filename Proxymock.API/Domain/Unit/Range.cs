using System.Collections;

namespace Proxymock.API.Domain.Unit;

public record Range()
{
    const int DefaultMax = int.MaxValue;
    const int DefaultMin = int.MinValue;

    public int Min { get; init; } = DefaultMax;
    public int Max { get; init; } = DefaultMin;
}