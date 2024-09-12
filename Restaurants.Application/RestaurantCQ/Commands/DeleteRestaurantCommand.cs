using MediatR;

namespace Restaurants.Application.RestaurantCQ.Commands;

public record DeleteRestaurantCommand(Guid Id): IRequest<bool?>;