namespace BuberDinner.Domain.Dinners;

using Common;
using Common.ValueObjects;

using Entities;

using Enums;

using Hosts.ValueObjects;

using Menus.ValueObjects;

using ValueObjects;

public sealed class Dinner : AggregateRoot<DinnerId>, ITrackable
{
    private readonly List<Reservation> _reservations = new();

    private Dinner(
        DinnerId id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime? startedDateTime,
        DateTime? endedDateTime,
        DinnerStatus status,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location)
        : base(id)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
    }

    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime? StartedDateTime { get; }
    public DateTime? EndedDateTime { get; }
    public DinnerStatus Status { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; }

    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }

    public static Dinner SpawnOne(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime? startedDateTime,
        DateTime? endedDateTime,
        DinnerStatus status,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location)
    {
        return new Dinner(
            DinnerId.SpawnUniqueOne(),
            name,
            description,
            startDateTime,
            endDateTime,
            startedDateTime,
            endedDateTime,
            status,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location);
    }
}