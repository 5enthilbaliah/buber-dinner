namespace BuberDinner.Application.Menus.Mappings;

using Domain.Menus;
using Domain.Menus.Entities;

using Mapster;

public class AppMenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<MenuItem, MenuItemResult>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuSection, MenuSectionResult>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<Menu, MenuResult>()
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(x => x.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(x => x.Value));
    }
}