using AutoMapper;
using Mecanillama.API.Customers.Domain.Model;
using Mecanillama.API.Customers.Resources;
using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Mechanics.Resources;

namespace Mecanillama.API.Customers.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCustomerResource, Customer>();
        CreateMap<SaveMechanicResource, Mechanic>();
    }
}