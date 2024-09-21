namespace Proxymock.API.Domain.Unit.Address;

public record BuildingNumber : Address
{
    public override TypesEnum DataType { get; } = TypesEnum.BuildingNumber;
}