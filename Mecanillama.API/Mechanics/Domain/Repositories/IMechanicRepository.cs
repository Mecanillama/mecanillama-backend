using Mecanillama.API.Mechanics.Domain.Models;

namespace Mecanillama.API.Mechanics.Domain.Repositories;

public interface IMechanicRepository
{
    Task<IEnumerable<Mechanic>> ListAsync();
    Task AddAsync(Mechanic mechanic);
    Task<Mechanic> FindByIdAsync(long id);
    Task<Mechanic> FindByUserIdAsync(long userId);
    void Update(Mechanic mechanic);
    void Remove(Mechanic mechanic);
}