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
        return await _mechanicRepository.ListAsync();
    }

    public async Task<MechanicResponse> SaveAsync(Mechanic mechanic)
    {
        try
        {
            await _mechanicRepository.AddAsync(mechanic);
            await _unitOfWork.CompleteAsync();
            return new MechanicResponse(mechanic);
        }
        catch (Exception e) 
        {
            return new MechanicResponse($"An error occurred while saving the mechanic: {e.Message}");
        }
    }

    public async Task<MechanicResponse> UpdateAsync(int id, Mechanic mechanic)
    {
        var existingMechanic = await _mechanicRepository.FindByIdAsync(id);
        if (existingMechanic == null)
        {
            return new MechanicResponse("Mechanic not found ");
        }

        existingMechanic.Name = mechanic.Name;

        try
        {
            _mechanicRepository.Update(existingMechanic);
            await _unitOfWork.CompleteAsync();

            return new MechanicResponse(existingMechanic);
        }
        catch (Exception e)
        {
            return new MechanicResponse($"An error occurred while updating the mechanic: {e.Message}");
        }
    }

    public async Task<MechanicResponse> DeleteAsync(int id)
    {
        var existingMechanic = await _mechanicRepository.FindByIdAsync(id);

        if (existingMechanic == null)
            return new MechanicResponse("Customer not found.");

        try
        {
            _mechanicRepository.Remove(existingMechanic);
            await _unitOfWork.CompleteAsync();

            return new MechanicResponse(existingMechanic);
        }
        catch (Exception e)
        {
            return new MechanicResponse($"An error occurred while deleting the mechanic: {e.Message}");
        }
    }
}