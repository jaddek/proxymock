namespace Proxymock.API.Domain.Unit.Address;

public record StreetName : Address
{
    public override TypesEnum DataType { get; } = TypesEnum.StreetName;
}