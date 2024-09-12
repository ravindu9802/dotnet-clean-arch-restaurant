using MediatR;
using Restaurants.Application.RestaurantCQ.Commands;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.RestaurantCQ.Handlers.CommandHandlers;

public class AddRestaurantCommandHandler : IRequestHandler<AddRestaurantCommand, Guid?>
{
    private readonly IRestaurantRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AddRestaurantCommandHandler(IRestaurantRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid?> Handle(AddRestaurantCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.CreateRestaurantAsync(request.Restaurant);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }
}
