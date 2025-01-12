
using Restaurants.Domain.Exceptions;

namespace Restaurants.API.Middleware
{
    public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFound)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFound.Message);
                logger.LogWarning(notFound.Message);
            }
            catch (ForbidException forbid)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("You are not authorized to perform this action");
                logger.LogWarning(forbid.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}

