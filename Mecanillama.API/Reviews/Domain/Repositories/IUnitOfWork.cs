namespace Mecanillama.API.Reviews.Domain.Repositories;

public interface IUnitOfWork {
    Task CompleteAsync();
}