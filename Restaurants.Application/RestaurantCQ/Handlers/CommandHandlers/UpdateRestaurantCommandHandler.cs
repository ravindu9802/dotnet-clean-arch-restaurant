using MediatR;
using Restaurants.Application.RestaurantCQ.Commands;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.RestaurantCQ.Handlers.CommandHandlers;

public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand, bool?>
{
    private readonly IRestaurantRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRestaurantCommandHandler(IRestaurantRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool?> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.UpdateRestaurantAsync(request.Id, request.Restaurant);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }
}
