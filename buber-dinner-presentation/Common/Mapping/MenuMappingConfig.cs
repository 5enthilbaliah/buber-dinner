namespace BuberDinner.Presentation.Common.Mapping;

using Application.Menus;
using Application.Menus.Commands.CreateMenu;

using Contracts.Menus;

using Mapster;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Requests
        config.NewConfig<(CreateMenuRequest request, string hostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.hostId)
            .Map(dest => dest, src => src.request);

        // Response
        config.NewConfig<MenuItemResult, MenuItemResponse>();
        config.NewConfig<MenuSectionResult, MenuSectionResponse>();
        config.NewConfig<MenuResult, MenuResponse>();
    }
}