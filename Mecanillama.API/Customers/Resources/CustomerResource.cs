using Mecanillama.API.Shared.Resources;

namespace Mecanillama.API.Customers.Resources;

public class CustomerResource
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string CarMake { get; set; }
    public long UserId { get; set; }
}