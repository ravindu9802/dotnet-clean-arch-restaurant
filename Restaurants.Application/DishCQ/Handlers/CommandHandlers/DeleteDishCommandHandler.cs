using MediatR;
using Restaurants.Application.DishCQ.Commands;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.DishCQ.Handlers.CommandHandlers;

internal class DeleteDishCommandHandler : IRequestHandler<DeleteDishCommand, bool?>
{
    private readonly IDishRepository _repository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteDishCommandHandler(IDishRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<bool?> Handle(DeleteDishCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.DeleteDishAsync(request.RestaurantId, request.DishId);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }
}
