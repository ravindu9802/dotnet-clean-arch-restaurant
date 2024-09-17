using MediatR;
using Restaurants.Application.DishCQ.Commands;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.DishCQ.Handlers.CommandHandlers;

internal class CreateDishCommandHandler : IRequestHandler<CreateDishCommand, Guid?>
{
    private readonly IDishRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDishCommandHandler(IDishRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid?> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.CreateDishAsync(request.Dish);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }
}
