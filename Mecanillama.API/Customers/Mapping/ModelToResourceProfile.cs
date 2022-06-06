using AutoMapper;
using Mecanillama.API.Customers.Domain.Model;
using Mecanillama.API.Customers.Resources;

namespace Mecanillama.API.Customers.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Customer, CustomerResource>();
    }

}