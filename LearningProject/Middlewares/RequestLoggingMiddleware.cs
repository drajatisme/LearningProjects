using System.Diagnostics;

namespace LearningProject.Middlewares
{
    /// <summary>
    /// source: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/write?view=aspnetcore-6.0
    /// </summary>
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string user = context.User.Identity.Name ?? "Anon";
            var start = DateTime.Now;
            _logger.LogWarning($"{user} hitting {context.Request.Path} at {start}");
            await _next(context);
            TimeSpan span = DateTime.Now - start;
            _logger.LogWarning($"{user} hitted {context.Request.Path} at {DateTime.Now} for {span.Milliseconds}ms");
        }
    }

    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLoggingMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
