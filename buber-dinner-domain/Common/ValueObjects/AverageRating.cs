namespace BuberDinner.Domain.Common.ValueObjects;

public class AverageRating : ValueObject
{
    private AverageRating(double value, int numOfRatings)
    {
        Value = value;
        NumOfRatings = numOfRatings;
    }

    public double Value { get; private set; }
    public int NumOfRatings { get; private set; }

    public static AverageRating SpawnOne(double rating = 0, int numOfRatings = 0)
    {
        return new AverageRating(rating, numOfRatings);
    }

    internal void AddNewRating(Rating rating)
    {
        Value = ((Value * NumOfRatings) + rating.Value) / ++NumOfRatings;
    }

    internal void RemoveRating(Rating rating)
    {
        Value = ((Value * NumOfRatings) - rating.Value) / --NumOfRatings;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}