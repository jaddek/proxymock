using Bogus;
using Proxymock.API.Domain.Unit;
using Proxymock.API.Domain.Unit.Address;
using Proxymock.API.Domain.Unit.Base;

namespace Proxymock.API.Domain;

public class Runner
{
    private readonly Faker _faker = new();
    private readonly Random _random = new();

    public dynamic? ResolveGen(Unit.Unit unit)
    {
        if (unit is Address address)
        {
            return GenAddress(address);
        }

        return unit.GetType().FullName switch
        {
            "Proxymock.API.Domain.Unit.Id" => GenId(unit as Id),
            "Proxymock.API.Domain.Unit.Uuid" => GenUuidV4(unit as Uuid),
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

        return IsNextUnitNull(unit) ? null : result;
    }

    private bool IsNextUnitNull(Unit.Unit unit, int chance = 50)
    {
        return unit.IsNullable && _random.Next(0, 100) < chance;
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
}