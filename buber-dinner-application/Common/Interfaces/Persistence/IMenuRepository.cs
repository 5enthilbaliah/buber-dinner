namespace BuberDinner.Application.Common.Interfaces.Persistence;

using Domain.Hosts.ValueObjects;
using Domain.Menus;
using Domain.Menus.ValueObjects;

public interface IMenuRepository
{
    Task AddAsync(Menu menu, CancellationToken cancellationToken = default);
    Task<Menu?> GetAsync(HostId hostId, MenuId menuId, CancellationToken cancellationToken = default);
}