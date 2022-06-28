using Mecanillama.API.Security.Domain.Models;

namespace Mecanillama.API.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}