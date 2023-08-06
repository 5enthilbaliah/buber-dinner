namespace BuberDinner.Contracts.Menus;

public record MenuItemResponse(
    string Id,
    string Name,
    string Description);

public record MenuSectionResponse(
    string Id,
    string Name,
    string Description,
    List<MenuItemResponse> Items);

public record MenuResponse(
    string Id,
    string Name,
    string Description,
    float AverageRating,
    List<MenuSectionResponse> Sections,
    string HostId,
    List<string> DinnerIds,
    List<string> MenuReviewIds,
    DateTime CreatedOn,
    DateTime ModifiedOn);