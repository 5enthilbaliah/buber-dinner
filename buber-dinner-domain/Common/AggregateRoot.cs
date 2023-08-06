namespace BuberDinner.Domain.Common;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
#pragma warning disable cs8618
    protected AggregateRoot()
    {
    }
#pragma warning restore cs8618

    protected AggregateRoot(TId id) : base(id)
    {
    }
}