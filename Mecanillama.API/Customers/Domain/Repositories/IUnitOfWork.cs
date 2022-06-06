namespace Mecanillama.API.Customers.Domain.Repositories;

public interface IUnitOfWork {
    Task CompleteAsync();
}