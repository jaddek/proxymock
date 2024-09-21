using Bogus;
using Proxymock.API.Domain.Unit;
using Proxymock.API.Domain.Unit.Address;

namespace Proxymock.API.Domain;

public class Runner2
{
    private readonly Faker _faker = new();
    private readonly Random _random = new();
    public dynamic? ResolveGen(BaseUnit unit)
    {
        if (unit is Address address)
        {
            return GenAddress(address);
        }

        return unit.GetType().FullName switch
        {
            "Proxymock.API.Domain.Unit.Id" => GenId(unit as Id),
            "Proxymock.API.Domain.Unit.Uuid" => GenUuidV4(unit as Uuid),
            "Proxymock.API.Domain.Unit.Title" => GenTitle(unit as Title),
            _ => null
        };
    }

    private string? GenAddress(Address unit)
    {
        string? result = null;
        switch (unit.DataType)
        {
            case TypesEnum.City:
                result = _faker.Address.City();
                break;
            case TypesEnum.ZipCode:
                result = _faker.Address.ZipCode();
                break;
            case TypesEnum.StreetAddress:
                result = _faker.Address.StreetAddress();
                break;
            case TypesEnum.StreetName:
                result = _faker.Address.StreetName();
                break;
            case TypesEnum.BuildingNumber:
                result = _faker.Address.BuildingNumber();
                break;
            case TypesEnum.Country:
                result = _faker.Address.Country();
                break;
        }

        if (unit.Nullable && _random.Next(0, 100) < 50)
        {
            result = null;
        }
        
        return result;
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

    private static Guid? GenUuidV4(Uuid? unit)
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

    private static string? GenTitle(Title? unit)
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