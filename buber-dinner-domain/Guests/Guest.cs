namespace BuberDinner.Domain.Guests;

using Bills.ValueObjects;

using Common;
using Common.ValueObjects;

using Dinners.ValueObjects;

using Entities;

using MenuReview.ValueObjects;

using Users.ValueObjects;

using ValueObjects;

public sealed class Guest : AggregateRoot<GuestId, Guid>, ITrackable
{
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<GuestRating> _ratings = new();
    private readonly List<DinnerId> _upcomingDinnerIds = new();

    private Guest(
        GuestId id,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdOn,
        DateTime modifiedOn)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; }

    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<GuestRating> Ratings => _ratings.AsReadOnly();

    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }

    public static Guest SpawnOne(
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdOn,
        DateTime modifiedOn)
    {
        return new Guest(
            GuestId.SpawnUniqueOne(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            createdOn,
            modifiedOn);
    }
}