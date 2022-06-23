using Mecanillama.API.Shared.Resources;

namespace Mecanillama.API.Mechanics.Resources;

public class MechanicResource
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public long Phone { get; set; }
    public long UserId { get; set; }
    
}