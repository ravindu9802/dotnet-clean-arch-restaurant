using MediatR;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.RestaurantCQ.Queries;

public record GetRestaurantByIdQuery(Guid Id) : IRequest<Restaurant?>;
