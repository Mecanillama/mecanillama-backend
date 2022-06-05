using Mecanillama.API.Customers.Domain.Model;
using Mecanillama.API.Customers.Domain.Services.Communication;

namespace Mecanillama.API.Customers.Domain.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> ListAsync();
    Task<CustomerResponse> SaveAsync(Customer category);
    Task<CustomerResponse> UpdateAsync(int id, Customer category);
    Task<CustomerResponse> DeleteAsync(int id);
}