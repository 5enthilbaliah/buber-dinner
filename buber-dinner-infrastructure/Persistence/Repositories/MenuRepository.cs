namespace BuberDinner.Infrastructure.Persistence.Repositories;

using Application.Common.Interfaces.Persistence;

using Domain.Common.Errors;
using Domain.Menus;

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
}