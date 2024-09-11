using Confluent.Kafka;

namespace Proxymock.API.Domain.Unit;

public record Uuid(
): BaseUnit
{
    public  bool Nullable { get; set; }
    
    public static Uuid Build(bool nullable)
    {
        return new Uuid
        {
            Nullable = nullable,
        };
    }
}