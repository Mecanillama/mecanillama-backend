using AutoMapper;
using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Mechanics.Domain.Services;
using Mecanillama.API.Mechanics.Resources;
using Mecanillama.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Mecanillama.API.Mechanics.Controllers;

[Route("/api/v1/[controller]")]
[SwaggerTag("Create, read, update and delete Mechanics")]
public class MechanicsController : ControllerBase
{
    private readonly IMechanicService _mechanicService;
    private readonly IMapper _mapper;

    public MechanicsController(IMechanicService mechanicService, IMapper mapper) {
        _mechanicService = mechanicService;
        _mapper = mapper;
    }
    
    [SwaggerOperation(
        Summary = "Get all Mechanics",
        Description = "Get Method for all Mechanics",
        OperationId = "GetAllMechanics")]
    [SwaggerResponse(200, "All Mechanics returned", typeof(IEnumerable<MechanicResource>))]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<MechanicResource>), 200)]
    public async Task<IEnumerable<MechanicResource>> GetAllSync() {
        var mechanics = await _mechanicService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Mechanic>, IEnumerable<MechanicResource>>(mechanics);
        
        return resources;
    }
    
    [SwaggerOperation(
        Summary = "Get Mechanic by Id",
        Description = "Get Mechanic by Id",
        OperationId = "GetMechanicById")]
    [SwaggerResponse(200, "Mechanic returned", typeof(MechanicResource))]

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(MechanicResource), 200)]
    [ProducesResponseType(typeof(BadRequestResult), 404)]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await _mechanicService.GetByIdAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var mechanicResult = _mapper.Map<Mechanic, MechanicResource>(result.Resource);

        return Ok(mechanicResult);
    }

    [SwaggerOperation(
        Summary = "Get Mechanic by User Id",
        Description = "Get Mechanic by User Id",
        OperationId = "GetMechanicByUserId")]
    [SwaggerResponse(200, "Mechanic returned", typeof(MechanicResource))]

    [HttpGet("uid/{userId}")]
    [ProducesResponseType(typeof(MechanicResource), 200)]
    [ProducesResponseType(typeof(BadRequestResult), 404)]
    public async Task<IActionResult> GetByUserIdAsync(long userId)
    {
        var result = await _mechanicService.GetByUserIdAsync(userId);

        if (!result.Success)
            return BadRequest(result.Message);

        var mechanicResult = _mapper.Map<Mechanic, MechanicResource>(result.Resource);

        return Ok(mechanicResult);
    }
    
    [SwaggerOperation(
        Summary = "Save Mechanic",
        Description = "Save Mechanic",
        OperationId = "SaveMechanic")]
    [SwaggerResponse(201, "Mechanic saved", typeof(MechanicResource))]
    
    [HttpPost]
    [ProducesResponseType(typeof(MechanicResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] SaveMechanicResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var mechanic = _mapper.Map<SaveMechanicResource, Mechanic>(resource);

        var result = await _mechanicService.SaveAsync(mechanic);

        if (!result.Success)
            return BadRequest(result.Message);

        var mechanicResource = _mapper.Map<Mechanic, MechanicResource>(result.Resource);

        return Ok(mechanicResource);
    }
    
    [SwaggerOperation(
        Summary = "Update Mechanic",
        Description = "Update Mechanic",
        OperationId = "UpdateMechanic")]
    [SwaggerResponse(200, "Mechanic updated", typeof(MechanicResource))]
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMechanicResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var mechanic = _mapper.Map<SaveMechanicResource, Mechanic>(resource);

        var result = await _mechanicService.UpdateAsync(id, mechanic);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var mechanicResource = _mapper.Map<Mechanic, MechanicResource>(result.Resource);

        return Ok(mechanicResource);
    }
    
    [SwaggerOperation(
        Summary = "Delete Mechanic",
        Description = "Delete Mechanic",
        OperationId = "DeleteMechanic")]
    [SwaggerResponse(200, "Mechanic deleted", typeof(MechanicResource))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _mechanicService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var mechanicResource = _mapper.Map<Mechanic, MechanicResource>(result.Resource);

        return Ok(mechanicResource);
    }
}
