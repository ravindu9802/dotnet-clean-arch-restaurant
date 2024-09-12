using MediatR;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.RestaurantCQ.Commands;

public record UpdateRestaurantCommand(Guid Id, Restaurant Restaurant) : IRequest<bool?>;
