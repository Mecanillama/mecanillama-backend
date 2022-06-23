using Mecanillama.API.Mechanics.Domain.Models;

namespace Mecanillama.API.Mechanics.Domain.Repositories;

public interface IMechanicRepository
{
    Task<IEnumerable<Mechanic>> ListAsync();
    Task AddAsync(Mechanic mechanic);
    Task<Mechanic> FindByIdAsync(int id);
    void Update(Mechanic mechanic);
    void Remove(Mechanic mechanic);
}