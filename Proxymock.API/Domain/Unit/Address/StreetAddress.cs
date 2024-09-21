namespace Proxymock.API.Domain.Unit.Address;

public record StreetAddress : Address
{
    public override TypesEnum DataType { get; } = TypesEnum.StreetAddress;
}