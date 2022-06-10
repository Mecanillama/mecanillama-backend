using AutoMapper;
using Mecanillama.API.Appointments.Domain.Models;
using Mecanillama.API.Appointments.Domain.Services;
using Mecanillama.API.Appointments.Resources;
using Mecanillama.API.Customers.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Mecanillama.API.Appointments.Controllers;

[Route("/api/v1/[controller]")] 
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;
    private readonly IMapper _mapper;

    public AppointmentsController(IAppointmentService appointmentService, IMapper mapper) {
        _appointmentService = appointmentService;
        _mapper = mapper;
    }
    
    [SwaggerOperation(
        Summary = "Get all Appointments",
        Description = "Get of all Appointments",
        OperationId = "GetAllAppointments")]
    [SwaggerResponse(200, "All Appointments returned", typeof(IEnumerable<AppointmentResource>))]


    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AppointmentResource>), 200)]
    [ProducesResponseType(typeof(BadRequestResult), 404)]
    public async Task<IEnumerable<AppointmentResource>> GetAllAsync()
    {
        var appointments = await _appointmentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appointments);
        return resources;
    }
    
    
    
}