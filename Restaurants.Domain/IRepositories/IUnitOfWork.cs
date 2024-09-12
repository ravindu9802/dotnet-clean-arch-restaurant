namespace Restaurants.Domain.IRepositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
