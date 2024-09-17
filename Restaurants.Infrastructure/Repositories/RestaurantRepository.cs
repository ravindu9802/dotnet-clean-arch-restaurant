using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantRepository : IRestaurantRepository
{
    private readonly RestaurantDbContext _context;

    public RestaurantRepository(RestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<List<Restaurant>?> GetAllRestaurantsAsync()
    {
        return await _context.Restaurants.Include(r => r.Dishes).ToListAsync();
    }

    public async Task<Restaurant?> GetRestaurantByIdAsync(Guid id)
    {
        return await _context.Restaurants.FindAsync(id);
    }

    public async Task<Guid?> CreateRestaurantAsync(Restaurant restaurant)
    {
        await _context.Restaurants.AddAsync(restaurant);
        return restaurant.Id;
    }

    public async Task<bool?> UpdateRestaurantAsync(Guid id, Restaurant restaurant)
    {
        var item = await _context.Restaurants.FindAsync(id);
        if (item != null)
        {
            item.Name = restaurant.Name;
            item.Description = restaurant.Description;
            item.Address = restaurant.Address;
            item.Dishes = restaurant.Dishes;
            return true;
        }
        return false;
    }

    public async Task<bool?> DeleteRestaurantAsync(Guid id)
    {
        var item = await _context.Restaurants.FindAsync(id);
        if (item != null)
        {
            _context.Restaurants.Remove(item);
            return true;
        }
        return false;
    }

}
