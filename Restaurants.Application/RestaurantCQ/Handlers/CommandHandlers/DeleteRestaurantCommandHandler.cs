using MediatR;
using Restaurants.Application.RestaurantCQ.Commands;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.RestaurantCQ.Handlers.CommandHandlers;

public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, bool?>
{
    private readonly IRestaurantRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRestaurantCommandHandler(IRestaurantRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool?> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.DeleteRestaurantAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }
}
