using Mecanillama.API.Appointments.Domain.Repositories;
using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Mechanics.Domain.Repositories;
using Mecanillama.API.Shared.Domain.Repositories;
using Mecanillama.API.Shared.Persistence.Contexts;

namespace Mecanillama.API.Mechanics.Persistence.Repositories;

public class MechanicRepository : BaseRepository, IMechanicRepository
{
    public MechanicRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Mechanic>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Mechanic mechanic)
    {
        throw new NotImplementedException();
    }

    public async Task<Mechanic> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Mechanic mechanic)
    {
        throw new NotImplementedException();
    }

    public void Remove(Mechanic mechanic)
    {
        throw new NotImplementedException();
    }
}