using Microsoft.Extensions.DependencyInjection;
using NeuronLogisticsServer.Application.Abstractions.Storages;
using NeuronLogisticsServer.Application.Abstractions.Token;
using NeuronLogisticsServer.Infrastructure.Enums;
using NeuronLogisticsServer.Infrastructure.Services.Storages;
using NeuronLogisticsServer.Infrastructure.Services.Storages.Azure;
using NeuronLogisticsServer.Infrastructure.Services.Storages.Local;
using NeuronLogisticsServer.Infrastructure.Services.Token;

namespace NeuronLogisticsServer.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }

        public static void AddStroage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }

        public static void AddStroage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:
                    //serviceCollection.AddScoped<IStorage, AWSStorage>();
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
