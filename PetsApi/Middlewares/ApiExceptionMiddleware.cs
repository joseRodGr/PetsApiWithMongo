using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Net;
using Microsoft.Extensions.Hosting;
using PetsApi.Helpers;
using System.Text.Json;

namespace PetsApi.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ApiExceptionMiddleware(RequestDelegate next, ILogger<ApiExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
            
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var apiError = _env.IsDevelopment()
                    ? new ApiError(context.Response.StatusCode, ex.Message, context.TraceIdentifier, ex.StackTrace)
                    : new ApiError(context.Response.StatusCode, "Internal Server Error",context.TraceIdentifier);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var apiErrorJson = JsonSerializer.Serialize(apiError, options);

                await context.Response.WriteAsync(apiErrorJson);
            }
            
        }
    }

}
