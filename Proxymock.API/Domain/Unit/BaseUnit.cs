using Proxymock.API.Domain.Unit.Address;

namespace Proxymock.API.Domain.Unit;

public abstract record BaseUnit
{
    public virtual TypesEnum DataType { get; } = TypesEnum.Unit;
}