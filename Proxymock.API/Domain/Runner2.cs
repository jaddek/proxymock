using Bogus;
using Proxymock.API.Domain.Unit;

namespace Proxymock.API.Domain;

public static class Runner2
{
    public static dynamic? ResolveGen(BaseUnit unit)
    {
        return unit.GetType().Name switch
        {
            "Id" => GenId(unit as Id),
            "Uuid" => GenUuidV4(unit as Uuid),
            "Title" => GenTitle(unit as Title),
            _ => null
        };
    }

    private static int? GenId(Id? unit)
    {
        if (unit == null)
        {
            throw new Exception("Invalid unit");
        }
        
        if (unit.Nullable)
        {
            return null;
        }

        var min = unit.Unsigned ? 0 : unit.Range.Min;
        var max = unit.Range.Max;

        var random = new Random();

        return random.Next(min, max);
    }

    public static Guid? GenUuidV4(Uuid? unit)
    {
        if (unit == null)
        {
            throw new Exception("Invalid unit");
        }
        
        if (unit.Nullable)
        {
            return null;
        }

        return Guid.NewGuid();
    }

    public static string? GenTitle(Title? unit)
    {
        if (unit == null)
        {
            throw new Exception("Invalid unit");
        }
        
        if (unit.Nullable)
        {
            return null;
        }

        var faker = new Faker();

        return faker.Company.CompanyName();
    }
}