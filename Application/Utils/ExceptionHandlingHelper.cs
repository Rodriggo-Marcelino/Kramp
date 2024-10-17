using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.ExceptionHandler
{
    public class ExceptionHandlingHelper
    {
        private const string UNHANDLED_EXCEPTION_MSG = "Unhandled exception has occurred.";

        private readonly ILogger<ExceptionHandlingHelper> _logger;

        private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web)
        {
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };

        public ExceptionHandlingHelper(ILogger<ExceptionHandlingHelper> logger)
        {
            _logger = logger;
        }

        public ProblemDetails CreateProblemDetails(HttpContext httpContext, Exception exception, string errorCode)
        {
            var statusCode = httpContext.Response.StatusCode;
            var reasonPhrase = ReasonPhrases.GetReasonPhrase(statusCode);

            if (string.IsNullOrEmpty(reasonPhrase))
            {
                reasonPhrase = UNHANDLED_EXCEPTION_MSG;
            }

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = reasonPhrase,
                Detail = exception.ToString(),
                Extensions =
                {
                    [nameof(errorCode)] = errorCode,
                    ["traceId"] = httpContext.TraceIdentifier,
                    ["data"] = exception.Data
                }
            };

            return problemDetails;
        }

        public string ToJson(ProblemDetails problemDetails)
        {
            try
            {
                return JsonSerializer.Serialize(problemDetails, SerializerOptions);
            }
            catch (Exception ex)
            {
                const string msg = "An exception has occurred while serializing error to JSON";
                _logger.LogError(ex, msg);
            }

            return string.Empty;
        }
    }
}