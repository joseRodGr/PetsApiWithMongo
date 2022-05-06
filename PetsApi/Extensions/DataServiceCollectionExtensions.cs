using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PetsApi.Data;

namespace PetsApi.Extensions
{
    public static class DataServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PetStoreDataSettings>(configuration.GetSection(nameof(PetStoreDataSettings)));

            services.AddSingleton<IPetStoreDataSettings>(sp =>
                sp.GetRequiredService<IOptions<PetStoreDataSettings>>().Value);

            services.AddSingleton<IMongoClient>(s =>
                new MongoClient(configuration.GetSection("PetStoreDataSettings")["ConnectionString"]));

            return services;
        }
    }
}
