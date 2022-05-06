using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace PetsApi.Extensions
{
    public static class MvcServiceCollectionExtensions
    {
        public static IServiceCollection AddMvcAppServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PetsApi", Version = "v1" });
            });

            return services;
        }
    }
}
