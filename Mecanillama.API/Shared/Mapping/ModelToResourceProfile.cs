using AutoMapper;
using Mecanillama.API.Appointments.Domain.Models;
using Mecanillama.API.Appointments.Resources;
using Mecanillama.API.Customers.Domain.Model;
using Mecanillama.API.Customers.Resources;
using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Mechanics.Resources;
using Mecanillama.API.Reviews.Domain.Models;
using Mecanillama.API.Reviews.Resources;
using Mecanillama.API.Security.Domain.Models;
using Mecanillama.API.Security.Domain.Services.Communication;
using Mecanillama.API.Security.Resources;

namespace Mecanillama.API.Customers.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Customer, CustomerResource>();
        CreateMap<Mechanic, MechanicResource>();
        CreateMap<Appointment, AppointmentResource>();
        CreateMap<Review, ReviewResource>();
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }

}