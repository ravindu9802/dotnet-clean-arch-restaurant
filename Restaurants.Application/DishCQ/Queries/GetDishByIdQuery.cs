using MediatR;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.DishCQ.Queries;

public record GetDishByIdQuery(Guid RestaurantId, Guid DishId) : IRequest<Dish?>;
