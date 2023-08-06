namespace BuberDinner.Domain.Bills.ValueObjects;

using Common;

public class BillId : ValueObject
{
    private BillId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static BillId SpawnUniqueOne()
    {
        return new BillId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}