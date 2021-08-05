using Microsoft.AspNetCore.Builder;
using Notification.Middlewares;

namespace Notification.Extensions
{
    public static class RequestLoggerMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestLoggerMiddleware>();
        }
    }
}
