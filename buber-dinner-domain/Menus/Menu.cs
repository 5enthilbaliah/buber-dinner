namespace BuberDinner.Domain.Menus;

using Common;
using Common.ValueObjects;

using Dinners.ValueObjects;

using Entities;

using Hosts.ValueObjects;

using MenuReview.ValueObjects;

using ValueObjects;

public sealed class Menu : AggregateRoot<MenuId>, ITrackable
{
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<MenuSection> _sections = new();

    private Menu(
        MenuId id,
        string name,
        string description,
        HostId hostId,
        AverageRating averageRating,
        DateTime createdOn,
        DateTime modifiedOn)
        : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        AverageRating = averageRating;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
    }

    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public HostId HostId { get; }

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }

    public static Menu SpawnOne(
        string name,
        string description,
        HostId hostId,
        AverageRating averageRating,
        DateTime createdOn,
        DateTime modifiedOn)
    {
        return new Menu(
            MenuId.SpawnUniqueOne(),
            name,
            description,
            hostId,
            averageRating,
            createdOn,
            modifiedOn);
    }

    public static Menu SpawnOne(
        HostId hostId,
        string name,
        string description,
        List<MenuSection> sections)
    {
        var menu = new Menu(
            MenuId.SpawnUniqueOne(),
            name,
            description,
            hostId,
            AverageRating.SpawnOne(),
            DateTime.UtcNow,
            DateTime.UtcNow);

        if (sections.Any())
        {
            menu._sections.AddRange(sections);
        }

        return menu;
    }
}