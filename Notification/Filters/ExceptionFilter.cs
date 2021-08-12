using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Notification.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public ExceptionFilter(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger<ExceptionFilter>();
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.Message);
        }
    }
}
