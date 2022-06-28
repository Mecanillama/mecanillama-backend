using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Mechanics.Domain.Services.Communication;

namespace Mecanillama.API.Mechanics.Domain.Services;

public interface IMechanicService
{
    Task<IEnumerable<Mechanic>> ListAsync();
    Task<MechanicResponse> GetByIdAsync(long id);
    Task<MechanicResponse> GetByUserIdAsync(long userId);
    Task<MechanicResponse> SaveAsync(Mechanic mechanic);
    Task<MechanicResponse> UpdateAsync(int id, Mechanic mechanic);
    Task<MechanicResponse> DeleteAsync(int id);
}