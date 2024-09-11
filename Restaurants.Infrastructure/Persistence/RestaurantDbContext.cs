using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence;

// primary constructor used here
internal class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : DbContext(options)
{
    internal DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server=localhost;Database=RestaurantDB;Persist Security Info=False;Integrated Security=SSPI;Encrypt=True;TrustServerCertificate=True;");
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Restaurant>().OwnsOne(r => r.Address);
    }

    // create migration
    // dotnet ef migrations add MigrationName --project Restaurants.Infrastructure --startup-project Restaurants.API

    // update db
    // dotnet ef database update --project Restaurants.Infrastructure --startup-project Restaurants.API
}
