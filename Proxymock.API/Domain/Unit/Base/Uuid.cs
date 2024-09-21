namespace Proxymock.API.Domain.Unit.Base;

public record Uuid : Unit
{
    public bool Nullable { get; set; }

    public static Uuid Build(bool nullable)
    {
        return new Uuid
        {
            Nullable = nullable,
        };
    }
}