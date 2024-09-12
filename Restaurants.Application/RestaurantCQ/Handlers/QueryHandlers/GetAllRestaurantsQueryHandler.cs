using MediatR;
using Restaurants.Application.RestaurantCQ.Queries;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.RestaurantCQ.Handlers.QueryHandlers;

public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, List<Restaurant>?>
{
    private readonly IRestaurantRepository _repository;

    public GetAllRestaurantsQueryHandler(IRestaurantRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Restaurant>?> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllRestaurantsAsync();
    }
}
