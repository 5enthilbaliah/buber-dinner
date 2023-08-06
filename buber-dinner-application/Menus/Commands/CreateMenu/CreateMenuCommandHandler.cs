namespace BuberDinner.Application.Menus.Commands.CreateMenu;

using Common.Interfaces.Persistence;
using Common.Interfaces.Services;

using Domain.Common.Errors;
using Domain.Hosts.ValueObjects;
using Domain.Menus;
using Domain.Menus.Entities;

using ErrorOr;

using MapsterMapper;

using MediatR;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<MenuResult>>
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMapper _mapper;
    private readonly IMenuRepository _menuRepository;


    public CreateMenuCommandHandler(IMenuRepository menuRepository,
        IDateTimeProvider dateTimeProvider,
        IMapper mapper)
    {
        _menuRepository = menuRepository ?? throw new ArgumentNullException(nameof(menuRepository));
        _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ErrorOr<MenuResult>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.HostId, out var hostId))
        {
            return Errors.Menu.InvalidHost;
        }

        var menu = Menu.SpawnOne(
            HostId.SpawnWith(hostId),
            request.Name,
            request.Description,
            request.Sections.ConvertAll(section =>
                MenuSection.SpawnOne(
                    section.Name,
                    section.Description,
                    section.Items.ConvertAll(item => MenuItem.SpawnOne(item.Name, item.Description))
                )
            ),
            _dateTimeProvider.UtcNow,
            _dateTimeProvider.UtcNow
        );

        await _menuRepository.AddAsync(menu, cancellationToken)
            .ConfigureAwait(false);

        return _mapper.Map<MenuResult>(menu);
    }
}