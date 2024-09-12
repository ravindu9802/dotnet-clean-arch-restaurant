using MediatR;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.RestaurantCQ.Commands;

public record AddRestaurantCommand(Restaurant Restaurant) : IRequest<Guid?>;