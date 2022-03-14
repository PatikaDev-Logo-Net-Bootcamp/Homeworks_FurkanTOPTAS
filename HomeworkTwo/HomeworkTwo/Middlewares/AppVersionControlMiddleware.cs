using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace HomeworkTwo.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AppVersionControlMiddleware
    {
        private readonly RequestDelegate _next;
        private IConfiguration _config;
        

        public AppVersionControlMiddleware(RequestDelegate next, IConfiguration config)
        {
            _config = config;
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            double versionHeader;
            double versionDefault; // app settigns

            if (httpContext.Request.Path=="/api/Home/Login/" || httpContext.Request.Path == "/api/Home/Register/")
            {
                return _next(httpContext);
            }
            else
            {
                double.TryParse(httpContext.Request.Headers["app-version"], out versionHeader); // Headerdan gelen data
                double.TryParse(_config.GetValue<string>("Version"), out versionDefault); // app setting den gelen data 

                if (versionHeader > versionDefault)
                {
                    return ErrorReturnException(httpContext,"Your version is bigger than my version");
                }
               
                return _next(httpContext);
            }

            

        }

        private async Task ErrorReturnException(HttpContext httpContext, String message)
        {
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await httpContext.Response.WriteAsync(message);
        }
   
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AppVersionControlMiddlewareExtensions
    {
        public static IApplicationBuilder UseAppVersionControlMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AppVersionControlMiddleware>();
        }
    }
}
