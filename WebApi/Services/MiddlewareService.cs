using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WebApi_Assign.Models;

namespace WebApi_Assign.Service
{
    public class MiddlewareService
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly MiddleDbContext _context;


        public MiddlewareService(RequestDelegate next, ILoggerFactory logFactory, MiddleDbContext contxt)
        {
            _next = next;

            _logger = logFactory.CreateLogger("MyMiddleware");
            _context = contxt;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            _logger.LogInformation("MyMiddleware executing..");

            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong");
                await HandleExceptionAsync(httpContext,ex);
            }

            await _next(httpContext); 

        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            await _next(context);

        }
    }

    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareService>();
        }
    }
}
