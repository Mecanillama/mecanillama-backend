namespace Mecanillama.API.Mechanics.Resources;

public class MechanicResource
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public long PhoneNumber { get; set; }
}