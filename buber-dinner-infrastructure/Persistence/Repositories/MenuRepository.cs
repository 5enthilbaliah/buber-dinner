namespace BuberDinner.Infrastructure.Persistence.Repositories;

using Application.Common.Interfaces.Persistence;

using Domain.Hosts.ValueObjects;
using Domain.Menus;
using Domain.Menus.ValueObjects;

using Microsoft.EntityFrameworkCore;

public class MenuRepository : IMenuRepository
{
    private readonly BuberDinnerDbContext _dbContext;

    public MenuRepository(BuberDinnerDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task AddAsync(Menu menu, CancellationToken cancellationToken = default)
    {
        _dbContext.Menus.Add(menu);
        await _dbContext.SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<Menu?> GetAsync(HostId hostId, MenuId menuId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Menus.FirstOrDefaultAsync(m => m.Id == menuId && m.HostId == hostId,
            cancellationToken).ConfigureAwait(false);
    }
}