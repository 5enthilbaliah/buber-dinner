namespace BuberDinner.Infrastructure.Persistence;

using Application.Common.Interfaces.Persistence;

using Domain.Menus;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();

    public async Task AddAsync(Menu menu, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
        _menus.Add(menu);
    }
}