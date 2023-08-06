namespace BuberDinner.Domain.Common;

public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
    where TId : AggregateRootId<TIdType>
{
#pragma warning disable cs8618
    protected AggregateRoot()
    {
    }
#pragma warning restore cs8618

    protected AggregateRoot(TId id)
    {
        Id = id;
    }

    public new AggregateRootId<TIdType> Id { get; protected set; } = null!;
}