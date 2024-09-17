using MediatR;

namespace Restaurants.Application.DishCQ.Commands;

public record DeleteDishCommand(Guid RestaurantId, Guid DishId) : IRequest<bool?>;