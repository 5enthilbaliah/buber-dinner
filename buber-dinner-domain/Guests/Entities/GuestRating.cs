namespace BuberDinner.Domain.Guests.Entities;

using Common;
using Common.ValueObjects;

using Dinners.ValueObjects;

using Hosts.ValueObjects;

using ValueObjects;

public class GuestRating : Entity<GuestRatingId>, ITrackable
{
    private GuestRating(
        GuestRatingId id,
        HostId hostId,
        DinnerId dinnerId,
        Rating rating,
        DateTime createdOn,
        DateTime modifiedOn)
        : base(id)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
    }

    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public Rating Rating { get; }

    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }

    public static GuestRating SpawnOne(
        HostId hostId,
        DinnerId dinnerId,
        Rating rating,
        DateTime createdOn,
        DateTime modifiedOn)
    {
        return new GuestRating(
            GuestRatingId.SpawnUniqueOne(),
            hostId,
            dinnerId,
            rating,
            createdOn,
            modifiedOn);
    }
}