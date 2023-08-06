namespace BuberDinner.Domain.Bills.ValueObjects;

using Common;

public class BillId : AggregateRootId<Guid>
{
    private BillId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static BillId SpawnUniqueOne()
    {
        return new BillId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}