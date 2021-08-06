using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Notification.Middlewares
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public RequestLoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Request: {0} {1}",
                    context.Request.Method,
                    context.Request.Path.Value);
                await _next(context);
            }
            finally
            {
                _logger.Log(LogLevel.Information, "Request: {0} {1}, response: {2}",
                    context.Request.Method,
                    context.Request.Path.Value,
                    context.Response.StatusCode);
            }
        }
    }
}
