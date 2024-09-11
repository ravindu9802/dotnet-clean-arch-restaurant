﻿namespace Restaurants.Domain.Entities;

public class Restaurant
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Address? Address { get; set; }
    public ICollection<Dish>? Dishes { get; set; }

}
