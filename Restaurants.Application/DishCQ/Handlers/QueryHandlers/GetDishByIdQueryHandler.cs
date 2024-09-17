using MediatR;
using Restaurants.Application.DishCQ.Queries;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.DishCQ.Handlers.QueryHandlers;

internal class GetDishByIdQueryHandler : IRequestHandler<GetDishByIdQuery, Dish?>
{
    private readonly IDishRepository _repository;

    public GetDishByIdQueryHandler(IDishRepository repository)
    {
        _repository = repository;
    }

    public Task<Dish?> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetDishByIdAsync(request.RestaurantId, request.DishId);
    }
}
