using Mecanillama.API.Shared.Resources;

namespace Mecanillama.API.Customers.Resources;

public class CustomerResource : PersonResource
{
    public string CarMake { get; set; }
}