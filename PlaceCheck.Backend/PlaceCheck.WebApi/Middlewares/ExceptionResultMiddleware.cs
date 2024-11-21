using System.Net;
using PlaceCheck.Application.Exceptions;
using PlaceCheck.WebApi.Application.Responses;

namespace PlaceCheck.WebApi.Middlewares;

public class ExceptionResultMiddleware
{
    private readonly RequestDelegate _next;
    
    public ExceptionResultMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, ILogger<ExceptionResultMiddleware> logger)
    {
        try
        {
            await _next(httpContext);
        }
        catch (ErrorException e)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await httpContext.Response.WriteAsJsonAsync(new ErrorResponse { Error = e.Error });
        }
        catch (NotFoundException e)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await httpContext.Response.WriteAsJsonAsync(new NotFoundResponse { Message = e.Message });
        }
        catch (ApiException e)
        {
            logger.LogWarning($"API returned error: {e.StatusCode} - {e.ErrorContent}");
            httpContext.Response.StatusCode = (int)e.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(e.ErrorContent);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Fatal error");
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;    
            await httpContext.Response.WriteAsJsonAsync("Server error");
        }
    }
}

public static class ExceptionResultMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionResultMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionResultMiddleware>();
    }
}