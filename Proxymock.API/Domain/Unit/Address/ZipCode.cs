namespace Proxymock.API.Domain.Unit.Address;

public record ZipCode : Address
{
    public override TypesEnum DataType { get; } = TypesEnum.ZipCode;
}