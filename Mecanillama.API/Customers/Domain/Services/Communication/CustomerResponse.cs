using Mecanillama.API.Customers.Domain.Model;
using Mecanillama.API.Shared.Domain.Services.Communication;

namespace Mecanillama.API.Customers.Domain.Services.Communication;

public class CustomerResponse : BaseResponse<Customer> {
    public CustomerResponse(Customer resource) : base(resource) { }

    public CustomerResponse(string message) : base(message) { }
    
}