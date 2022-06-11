using Mecanillama.API.Shared.Persistence.Contexts;

namespace Mecanillama.API.Shared.Domain.Repositories;


public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository (AppDbContext context)
    {
        _context = context;
    }
}
