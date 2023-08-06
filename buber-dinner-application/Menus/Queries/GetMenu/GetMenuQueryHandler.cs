namespace BuberDinner.Application.Menus.Queries.GetMenu;

using Common.Interfaces.Persistence;

using Domain.Common.Errors;
using Domain.Hosts.ValueObjects;
using Domain.Menus.ValueObjects;

using ErrorOr;

using MapsterMapper;

using MediatR;

public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, ErrorOr<MenuResult>>
{
    private readonly IMapper _mapper;
    private readonly IMenuRepository _menuRepository;


    public GetMenuQueryHandler(IMenuRepository menuRepository,
        IMapper mapper)
    {
        _menuRepository = menuRepository ?? throw new ArgumentNullException(nameof(menuRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<ErrorOr<MenuResult>> Handle(GetMenuQuery request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.HostId, out var hostId))
        {
            return Errors.Menu.InvalidHost;
        }
        
        if (!Guid.TryParse(request.MenuId, out var menuId))
        {
            return Errors.Menu.InvalidMenu;
        }

        var menu = await _menuRepository.GetAsync(HostId.SpawnWith(hostId), MenuId.SpawnWith(menuId), cancellationToken)
            .ConfigureAwait(false);

        if (menu is null)
            return Errors.Menu.MenuNotFound;
        
        return _mapper.Map<MenuResult>(menu);
    }
}