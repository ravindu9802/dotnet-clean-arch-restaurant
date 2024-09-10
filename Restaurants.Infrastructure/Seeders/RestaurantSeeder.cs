using Microsoft.EntityFrameworkCore;
using Restaurants.Infrastructure.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantDbContext _context) : IRestaurantSeeder
{
    public async Task Seed()
    {
        await _context.Database.EnsureCreatedAsync();

        if (!await _context.Restaurants.AnyAsync())
        {
            IEnumerable<Restaurant> data = [
                new (){ Name = "KFC",
                        Description = "KFC (abbreviation of Kentucky Fried Chicken) is an American chain of fast food restaurants known for their fried chicken. It was started by Colonel Sanders in Corbin, Kentucky in 1952. They are now all over the world. They not only sell chicken, but also other food like salads and french fries.",
                        Address = new Address { Number = "13", City = "Kandy", Street = "Main Street", Postcode = 20000 },
                        Dishes = [
                            new Dish { Name = "KFC Biriyani", Price = 2.99M },
                            new Dish { Name = "KFC Chicken Bucket", Price = 1.99M }
                            ]
                },
                new (){ Name = "McDonald's",
                        Description = "McDonald's Corporation, doing business as McDonald's, is an American multinational fast food chain, founded in 1940 as a restaurant operated by Richard and Maurice McDonald, in San Bernardino, California, United States.",
                        Address = new Address { Number = "09", City = "Kandy", Street = "Main Street", Postcode = 20000 },
                        Dishes = [
                            new Dish { Name = "Burger", Price = 3.13M },
                            new Dish { Name = "Fries", Price = 0.97M }
                            ]
                },
            ];

            await _context.Restaurants.AddRangeAsync(data);
            await _context.SaveChangesAsync();
        }
    }

}
