namespace Proxymock.API.Domain.Unit;

public abstract record Unit
{
    public virtual TypesEnum DataType { get; } = TypesEnum.Unit;
    public virtual bool IsNullable { get; init; } = true;
}