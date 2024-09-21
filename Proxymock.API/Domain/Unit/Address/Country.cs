namespace Proxymock.API.Domain.Unit.Address;

public record Country : Address
{
    public override TypesEnum DataType { get; } = TypesEnum.Country;
}