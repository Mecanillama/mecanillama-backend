using Mecanillama.API.Shared.Resources;

namespace Mecanillama.API.Mechanics.Resources;

public class MechanicResource : PersonResource
{

    public string Description { get; set; }
    public long PhoneNumber { get; set; }
}