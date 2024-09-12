using Restaurants.Domain.IRepositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    private readonly RestaurantDbContext _context;

    public UnitOfWork(RestaurantDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
