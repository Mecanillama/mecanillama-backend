using Mecanillama.API.Customers.Persistence.Contexts;

namespace Mecanillama.API.Customers.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;
    //dependency injection
    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}