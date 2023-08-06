namespace BuberDinner.Domain.MenuReview;

using Common;
using Common.ValueObjects;

using Dinners.ValueObjects;

using Guests.ValueObjects;

using Hosts.ValueObjects;

using Menus.ValueObjects;

using ValueObjects;

public sealed class MenuReview : AggregateRoot<MenuReviewId>, ITrackable
{
    private MenuReview(
        MenuReviewId id,
        Rating rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdOn,
        DateTime modifiedOn)
        : base(id)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
    }

    public Rating Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }

    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }

    public static MenuReview SpawnOne(
        Rating rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdOn,
        DateTime modifiedOn)
    {
        return new MenuReview(
            MenuReviewId.SpawnUniqueOne(),
            rating,
            comment,
            hostId,
            menuId,
            guestId,
            dinnerId,
            createdOn,
            modifiedOn);
    }
}