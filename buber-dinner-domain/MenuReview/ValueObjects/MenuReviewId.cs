namespace BuberDinner.Domain.MenuReview.ValueObjects;

using Common;

public sealed class MenuReviewId : AggregateRootId<Guid>
{
    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static MenuReviewId SpawnUniqueOne()
    {
        return new MenuReviewId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static MenuReviewId SpawnWith(Guid id)
    {
        return new MenuReviewId(id);
    }
}