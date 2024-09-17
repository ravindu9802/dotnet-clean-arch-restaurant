using MediatR;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.DishCQ.Commands;

public record CreateDishCommand(Dish Dish) : IRequest<Guid?>;
