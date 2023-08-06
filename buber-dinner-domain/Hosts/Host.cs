namespace BuberDinner.Domain.Hosts;

using Common;
using Common.ValueObjects;

using Dinners.ValueObjects;

using Menus.ValueObjects;

using Users.ValueObjects;

using ValueObjects;

public sealed class Host : AggregateRoot<HostId, Guid>, ITrackable
{
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuId> _menuIds = new();

    private Host(
        HostId id,
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

    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }

    public static Host SpawnOne(
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdOn,
        DateTime modifiedOn)
    {
        return new Host(
            HostId.SpawnUniqueOne(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            createdOn,
            modifiedOn);
    }
}