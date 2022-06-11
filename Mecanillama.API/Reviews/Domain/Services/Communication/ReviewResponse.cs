using Mecanillama.API.Reviews.Domain.Models;
using Mecanillama.API.Shared.Domain.Services.Communication;

namespace Mecanillama.API.Reviews.Domain.Services.Communication;

public class ReviewResponse : BaseResponse<Review>
{
    public ReviewResponse(Review resource) : base(resource) { }

    public ReviewResponse(string message) : base(message) { }
}