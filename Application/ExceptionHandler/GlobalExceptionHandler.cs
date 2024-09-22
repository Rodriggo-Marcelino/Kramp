using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.ExceptionHandler
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly ExceptionHandlingHelper _helper;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, ExceptionHandlingHelper exceptionHandlingHelper)
        {
            _logger = logger;
            _helper = exceptionHandlingHelper;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            _logger.LogError(exception, exception.Message);

            var problemDetails = _helper.CreateProblemDetails(httpContext, exception, "GEH01");
            var json = _helper.ToJson(problemDetails);

            const string contentType = "application/problem+json";
            httpContext.Response.ContentType = contentType;
            await httpContext.Response.WriteAsync(json, cancellationToken);

            return true;
        }
    }
}
