namespace BuberDinner.Domain.Dinners.ValueObjects;

using Common;

public class Location : ValueObject
{
    private Location(
        string name,
        string address,
        double latitude,
        double longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string Name { get; }
    public string Address { get; }
    public double Latitude { get; }
    public double Longitude { get; }

    public static Location SpawnOne(
        string name,
        string address,
        double latitude,
        double longitude)
    {
        return new Location(
            name,
            address,
            latitude,
            longitude);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
    }
}