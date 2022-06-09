using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Shared.Domain.Services.Communication;

namespace Mecanillama.API.Mechanics.Domain.Services.Communication;

public class MechanicResponse : BaseResponse<Mechanic>
{
    public MechanicResponse(Mechanic resource) : base(resource) { }

    public MechanicResponse(string message) : base(message) { }
}