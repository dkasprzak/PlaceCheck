using System.Net;
using System.Runtime.InteropServices.JavaScript;
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