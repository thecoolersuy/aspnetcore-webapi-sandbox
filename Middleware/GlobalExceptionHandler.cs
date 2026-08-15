using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreWebApiSandbox;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        _logger.LogError(exception, " An unhandled exception occured.");

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(new 
        {
            error = "An unexpected error occured.Please try again later."
        }, cancellationToken);
        return true;
    }
}