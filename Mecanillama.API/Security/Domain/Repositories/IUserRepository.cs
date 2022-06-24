using Mecanillama.API.Security.Domain.Models;

namespace Mecanillama.API.Security.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(long id);
    Task<User> FindByEmailAsync(string username);
    bool ExistsByEmail(string username);
    User FindById(long id);
    void Update(User user);
    void Remove(User user);
}