using MediatR;
using Restaurants.Application.RestaurantCQ.Queries;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.RestaurantCQ.Handlers.QueryHandlers;

public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, Restaurant?>
{
    private readonly IRestaurantRepository _repository;

    public GetRestaurantByIdQueryHandler(IRestaurantRepository repository)
    {
        _repository = repository;
    }

    public async Task<Restaurant?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetRestaurantByIdAsync(request.Id);
    }
}
