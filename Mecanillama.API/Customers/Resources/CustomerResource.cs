namespace Mecanillama.API.Customers.Resources;

public class CustomerResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string CarMake { get; set; }
    public string Address { get; set; }
}