namespace BuberDinner.Application.Menus.Commands.CreateMenu;

using Common.Interfaces.Persistence;

using Domain.Common.Errors;
using Domain.Hosts.ValueObjects;
using Domain.Menus;
using Domain.Menus.Entities;

using ErrorOr;

using MapsterMapper;

using MediatR;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<MenuResult>>
{
    private readonly IMenuRepository _menuRepository;
    private readonly IMapper _mapper;


    public CreateMenuCommandHandler(IMenuRepository menuRepository, IMapper mapper)
    {
        _menuRepository = menuRepository ?? throw new ArgumentNullException(nameof(menuRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ErrorOr<MenuResult>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.HostId, out var hostId))
        {
            return Errors.Menu.InvalidHost;
        }
        
        var menu = Menu.SpawnOne(
            HostId.SpawnOne(hostId),
            request.Name,
            request.Description,
            request.Sections.ConvertAll(section =>
                MenuSection.SpawnOne(
                    section.Name,
                    section.Description,
                    section.Items.ConvertAll(item => MenuItem.SpawnOne(item.Name, item.Description))
                )
            )
        );

        await _menuRepository.AddAsync(menu, cancellationToken)
            .ConfigureAwait(false);

        return _mapper.Map<MenuResult>(menu);
    }
}