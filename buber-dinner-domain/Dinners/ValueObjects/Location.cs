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

    public string Name { get; private set; }
    public string Address { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }

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