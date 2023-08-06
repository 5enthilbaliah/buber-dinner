namespace BuberDinner.Application.Menus;

public record MenuResult(
    Guid Id,
    string Name,
    string Description,
    float AverageRating,
    List<MenuSectionResult> Sections,
    string HostId,
    List<Guid> DinnerIds,
    List<Guid> MenuReviewIds,
    DateTime CreatedOn,
    DateTime ModifiedOn);