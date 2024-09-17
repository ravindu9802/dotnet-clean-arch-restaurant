using MediatR;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.DishCQ.Queries;

public record GetAllDishesQuery(Guid RestaurantId) : IRequest<List<Dish>?>;
