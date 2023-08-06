namespace BuberDinner.Application.Common.Interfaces.Persistence;

using Domain.Menus;

public interface IMenuRepository
{
    Task AddAsync(Menu menu, CancellationToken cancellationToken = default);
}