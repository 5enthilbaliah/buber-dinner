namespace BuberDinner.Application.Menus;

public record MenuResult(
    Guid Id,
    string Name,
    string Description,
    float AverageRating,
    List<MenuSectionResult> Sections,
    string HostId,
    List<string> DinnerIds,
    List<string> MenuReviewIds,
    DateTime CreatedOn,
    DateTime ModifiedOn);