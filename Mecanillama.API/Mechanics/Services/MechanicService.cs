using Mecanillama.API.Customers.Domain.Repositories;
using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Mechanics.Domain.Repositories;
using Mecanillama.API.Mechanics.Domain.Services;
using Mecanillama.API.Mechanics.Domain.Services.Communication;
using Mecanillama.API.Shared.Domain.Repositories;

namespace Mecanillama.API.Mechanics.Services;

public class MechanicService : IMechanicService
{
    private readonly IMechanicRepository _mechanicRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MechanicService(IMechanicRepository mechanicRepository, IUnitOfWork unitOfWork) {
        _mechanicRepository = mechanicRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Mechanic>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<MechanicResponse> SaveAsync(Mechanic mechanic)
    {
        throw new NotImplementedException();
    }

    public async Task<MechanicResponse> UpdateAsync(int id, Mechanic mechanic)
    {
        throw new NotImplementedException();
    }

    public async Task<MechanicResponse> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}