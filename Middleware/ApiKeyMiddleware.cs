using Microsoft.AspNetCore.Http;

namespace TarjetasCuentasAPI.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        const string API_KEY = "12345678*";

        public ApiKeyMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            bool success = httpContext.Request.Headers.TryGetValue("API_KEY", out var apiKeyFromHttpHeader);
            if (!success)
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("The Api Key for accessing this endpoint is not available");
                return;
            }
            if (!API_KEY.Equals(apiKeyFromHttpHeader))
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("The authentication key is incorrect : Unauthorized access");
                return;
            }
            await _requestDelegate(httpContext);
        }
    }
    public static class ApiKeyMiddlewareExtension
    {
        public static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiKeyMiddleware>();
        }
    }
}
