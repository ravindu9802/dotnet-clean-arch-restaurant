using MediatR;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.RestaurantCQ.Queries;

public record GetAllRestaurantsQuery() : IRequest<List<Restaurant>?>;
