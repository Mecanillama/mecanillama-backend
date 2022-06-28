using System.Net;
using System.Net.Mime;
using System.Text.Json;
using Mecanillama.API.Security.Exceptions;

namespace Mecanillama.API.Security.Authorization.MIddleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = MediaTypeNames.Application.Json;

            switch (error)
            {
                case AppException e:
                    // Custom Application Exception
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                
                case KeyNotFoundException e:
                    // Not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                
                default:
                    // Unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(result);
        }
    }
}