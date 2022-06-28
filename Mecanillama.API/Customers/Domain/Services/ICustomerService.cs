using Mecanillama.API.Customers.Domain.Model;
using Mecanillama.API.Customers.Domain.Services.Communication;

namespace Mecanillama.API.Customers.Domain.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> ListAsync();
    Task<CustomerResponse> GetByIdAsync(long id);
    Task<CustomerResponse> GetByUserIdAsync(long userId);
    Task<CustomerResponse> SaveAsync(Customer category);
    Task<CustomerResponse> UpdateAsync(long id, Customer customer);
    Task<CustomerResponse> DeleteAsync(long id);
}