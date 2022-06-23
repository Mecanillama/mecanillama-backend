using Mecanillama.API.Appointments.Domain.Models;
using Mecanillama.API.Appointments.Domain.Services.Communication;

namespace Mecanillama.API.Appointments.Domain.Services;

public interface IAppointmentService
{
    Task<IEnumerable<Appointment>> ListAsync();
    Task<AppointmentResponse> SaveAsync(Appointment appointment);
    Task<AppointmentResponse> UpdateAsync(long id, Appointment appointment);
    Task<AppointmentResponse> DeleteAsync(long id);
}