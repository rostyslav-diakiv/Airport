using Microsoft.AspNetCore.Builder;

namespace Airport.WebApi.Extensions
{
    using Airport.WebApi.Middlewares;

    public static class HttpStatusCodeExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseHttpStatusCodeExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpStatusCodeExceptionMiddleware>();
        }
    }
}