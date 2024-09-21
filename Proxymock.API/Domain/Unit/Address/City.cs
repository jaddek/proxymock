namespace Proxymock.API.Domain.Unit.Address;

public record City : Address
{
    public override TypesEnum DataType { get; } = TypesEnum.City;
}