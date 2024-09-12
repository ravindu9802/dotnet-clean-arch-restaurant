using Restaurants.Domain.Entities;

namespace Restaurants.Domain.IRepositories;

public interface IRestaurantRepository
{
    Task<List<Restaurant>?> GetAllRestaurantsAsync();
    Task<Restaurant?> GetRestaurantByIdAsync(Guid id);
    Task<Guid?> CreateRestaurantAsync(Restaurant restaurant);
    Task<bool?> UpdateRestaurantAsync(Guid id, Restaurant restaurant);
    Task<bool?> DeleteRestaurantAsync(Guid id);
}
