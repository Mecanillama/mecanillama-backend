
using Mecanillama.API.Security.Authorization.Handlers.Interfaces;
using Mecanillama.API.Security.Authorization.Settings;
using Mecanillama.API.Security.Domain.Services;
using Mecanillama.API.Security.Exceptions;
using Microsoft.Extensions.Options;

namespace Mecanillama.API.Security.Authorization.MIddleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;


    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, IUserService userService, IJwtHandler handler)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        var userId = handler.ValidateToken(token);

        if (userId != null)
        {
            // On successful JWT validation, attach user info to context
            context.Items["User"] = await userService.GetByIdAsync(userId.Value);
        }

        await _next(context);
    }
}