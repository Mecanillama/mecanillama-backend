using AutoMapper;
using Mecanillama.API.Reviews.Domain.Models;
using Mecanillama.API.Reviews.Domain.Services;
using Mecanillama.API.Reviews.Resources;
using Mecanillama.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Mecanillama.API.Reviews.Controllers;

[Route("/api/v1/[controller]")]
[SwaggerTag("Create, read, update and delete Reviews")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly IMapper _mapper;

    public ReviewsController(IReviewService reviewService, IMapper mapper) {
        _reviewService = reviewService;
        _mapper = mapper;
    }
    
    [SwaggerOperation(
        Summary = "Get all Reviews",
        Description = "Get Method for all Reviews",
        OperationId = "GetAllReviews")]
    [SwaggerResponse(200, "All Reviews returned", typeof(IEnumerable<ReviewResource>))]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ReviewResource>), 200)]
    public async Task<IEnumerable<ReviewResource>> GetAllSync() {
        var reviews = await _reviewService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(reviews);
        
        return resources;
    }
    
    [SwaggerOperation(
        Summary = "Save Review",
        Description = "Save Review",
        OperationId = "SaveReview")]
    [SwaggerResponse(201, "Review saved", typeof(ReviewResource))]
    
    [HttpPost]
    [ProducesResponseType(typeof(ReviewResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] SaveReviewResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var review = _mapper.Map<SaveReviewResource, Review>(resource);

        var result = await _reviewService.SaveAsync(review);

        if (!result.Success)
            return BadRequest(result.Message);

        var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);

        return Ok(reviewResource);
    }
    
    [SwaggerOperation(
        Summary = "Update Review",
        Description = "Update Review",
        OperationId = "UpdateReview")]
    [SwaggerResponse(200, "Review updated", typeof(ReviewResource))]
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveReviewResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var review = _mapper.Map<SaveReviewResource, Review>(resource);

        var result = await _reviewService.UpdateAsync(id, review);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);

        return Ok(reviewResource);
    }
    
    [SwaggerOperation(
        Summary = "Delete Review",
        Description = "Delete Review",
        OperationId = "DeleteReview")]
    [SwaggerResponse(200, "Review deleted", typeof(ReviewResource))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _reviewService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);

        return Ok(reviewResource);
    }
}
