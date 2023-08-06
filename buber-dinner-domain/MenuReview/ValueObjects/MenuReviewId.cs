namespace BuberDinner.Domain.MenuReview.ValueObjects;

using Common;

public sealed class MenuReviewId : ValueObject
{
    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MenuReviewId SpawnUniqueOne()
    {
        return new MenuReviewId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}