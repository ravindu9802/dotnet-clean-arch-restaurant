using MediatR;
using Restaurants.Application.DishCQ.Queries;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.DishCQ.Handlers.QueryHandlers;

internal class GetAllDishesQueryHandler : IRequestHandler<GetAllDishesQuery, List<Dish>?>
{
    private readonly IDishRepository _repository;

    public GetAllDishesQueryHandler(IDishRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Dish>?> Handle(GetAllDishesQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetAllDishesByRestaurantAsync(request.RestaurantId);
    }
}
