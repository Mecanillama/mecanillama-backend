using Mecanillama.API.Customers.Domain.Model;

namespace Mecanillama.API.Customers.Domain.Repositories;

public interface ICustomerRepository {
    Task<IEnumerable<Customer>> ListAsync();
    Task AddAsync(Customer customer);
    Task<Customer> FindByIdAsync(long id);
    Task<Customer> FindByUserIdAsync(long userId);
    void Update(Customer customer);
    void Remove(Customer customer);
}