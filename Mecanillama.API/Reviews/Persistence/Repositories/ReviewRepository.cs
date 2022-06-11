using Mecanillama.API.Appointments.Domain.Repositories;
using Mecanillama.API.Reviews.Domain.Models;
using Mecanillama.API.Reviews.Domain.Repositories;
using Mecanillama.API.Shared.Domain.Repositories;
using Mecanillama.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Mecanillama.API.Reviews.Persistence.Repositories;

public class ReviewRepository : BaseRepository, IReviewRepository
{
    public ReviewRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Review>> ListAsync()
    {
        return await _context.Reviews.ToListAsync();
    }

    public async Task AddAsync(Review review)
    {
        await _context.Reviews.AddAsync(review);
    }

    public async Task<Review> FindByIdAsync(int id)
    {
        return await _context.Reviews.FindAsync(id);
    }

    public void Update(Review review)
    {
        _context.Reviews.Update(review);
    }

    public void Remove(Review review)
    {
        _context.Reviews.Remove(review);
    }
}