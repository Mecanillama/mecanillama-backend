using Mecanillama.API.Appointments.Domain.Models;
using Mecanillama.API.Shared.Domain.Services.Communication;

namespace Mecanillama.API.Appointments.Domain.Services.Communication;

public class AppointmentResponse : BaseResponse<Appointment>
{
    public AppointmentResponse(string message): base(message){}
    
    public AppointmentResponse(Appointment resource): base(resource) {}
    
}