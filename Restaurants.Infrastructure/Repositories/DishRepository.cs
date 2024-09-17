using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class DishRepository : IDishRepository
{
    private readonly RestaurantDbContext _context;

    public DishRepository(RestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<List<Dish>?> GetAllDishesByRestaurantAsync(Guid restaurantId)
    {
        return await _context.Dishes.AsNoTracking().Where(d => d.RestaurantId == restaurantId).ToListAsync();
    }

    public async Task<Dish?> GetDishByIdAsync(Guid restaurantId, Guid id)
    {
        return await _context.Dishes.Where(d =>  d.RestaurantId == restaurantId && d.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Guid?> CreateDishAsync(Dish dish)
    {
        await _context.Dishes.AddAsync(dish);
        return dish.Id;
    }

    public async Task<bool?> UpdateDishAsync(Guid id, Dish dish)
    {
        var item = await _context.Dishes.FindAsync(id);
        if (item != null)
        {
            item.Price = dish.Price;
            item.Name = dish.Name;
            item.KiloCalories = dish.KiloCalories;
            item.RestaurantId = dish.RestaurantId;
            return true;
        }
        return false;
    }

    public async Task<bool?> DeleteDishAsync(Guid restaurantId, Guid id)
    {
        var item = await _context.Dishes.Where(d => d.RestaurantId == restaurantId && d.Id == id).SingleOrDefaultAsync();
        if (item != null)
        {
           _context.Dishes.Remove(item);
            return true;
        }
        return false;
    }

    

    
}
