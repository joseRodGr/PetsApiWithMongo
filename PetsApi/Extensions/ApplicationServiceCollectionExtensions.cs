using Microsoft.Extensions.DependencyInjection;
using PetsApi.Helpers;
using PetsApi.Services;

namespace PetsApi.Extensions
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPetService, PetService>();
            services.AddAutoMapper(typeof(AutomapperProfiles).Assembly);

            return services;
        }
    }
}
