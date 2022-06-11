using AutoMapper;
using Mecanillama.API.Reviews.Domain.Models;
using Mecanillama.API.Reviews.Resources;

namespace Mecanillama.API.Reviews.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveReviewResource, Review>();
    }
}