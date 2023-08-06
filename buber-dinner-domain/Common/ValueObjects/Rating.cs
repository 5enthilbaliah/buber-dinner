namespace BuberDinner.Domain.Common.ValueObjects;

public class Rating : ValueObject
{
    private Rating(double value)
    {
        Value = value;
    }

    public double Value { get; }

    public static Rating SpawnOne(double value = 0)
    {
        return new Rating(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}