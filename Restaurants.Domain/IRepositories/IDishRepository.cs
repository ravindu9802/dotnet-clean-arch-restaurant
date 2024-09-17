using Restaurants.Domain.Entities;

namespace Restaurants.Domain.IRepositories;

public interface IDishRepository
{
    Task<List<Dish>?> GetAllDishesByRestaurantAsync(Guid restaurantId);
    Task<Dish?> GetDishByIdAsync(Guid restaurantId, Guid id);
    Task<Guid?> CreateDishAsync(Dish dish);
    Task<bool?> UpdateDishAsync(Guid id, Dish dish);
    Task<bool?> DeleteDishAsync(Guid restaurantId, Guid id);
}
