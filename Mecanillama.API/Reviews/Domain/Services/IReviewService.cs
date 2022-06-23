using Mecanillama.API.Reviews.Domain.Models;
using Mecanillama.API.Reviews.Domain.Services.Communication;

namespace Mecanillama.API.Reviews.Domain.Services;

public interface IReviewService
{
    Task<IEnumerable<Review>> ListAsync();
    Task<ReviewResponse> SaveAsync(Review review);
    Task<ReviewResponse> UpdateAsync(int id, Review review);
    Task<ReviewResponse> DeleteAsync(int id);
}