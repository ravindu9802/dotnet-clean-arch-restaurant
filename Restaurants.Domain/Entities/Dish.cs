﻿using System.Text.Json.Serialization;

namespace Restaurants.Domain.Entities;

public class Dish
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal KiloCalories { get; set; }
    public Guid RestaurantId { get; set; }

    [JsonIgnore]
    public Restaurant? Restaurant { get; set; }

}
