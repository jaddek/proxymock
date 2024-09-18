namespace Proxymock.API.Domain.Unit;

public record Title: BaseUnit
{
    public  bool Nullable { get; init; }
    public int Length { get; init; }
}