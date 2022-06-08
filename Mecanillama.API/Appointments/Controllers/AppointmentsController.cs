using AutoMapper;
using Mecanillama.API.Appointments.Domain.Services;
using Mecanillama.API.Customers.Domain.Services;
using Microsoft.AspNetCore.Mvc;

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
}