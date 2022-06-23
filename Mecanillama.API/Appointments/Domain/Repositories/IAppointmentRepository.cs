using Mecanillama.API.Appointments.Domain.Models;

namespace Mecanillama.API.Appointments.Domain.Repositories;

public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> ListAsync();
    Task AddAsync(Appointment appointment);
    Task<Appointment> FindByIdAsync(long id);
    void Update(Appointment appointment);
    void Remove(Appointment appointment);
}