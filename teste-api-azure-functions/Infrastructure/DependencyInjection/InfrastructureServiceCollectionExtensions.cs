using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using teste_api_azure_functions.Domain.Interfaces;
using teste_api_azure_functions.Infrastructure.Repositories.Persistence.Cosmos;

namespace teste_api_azure_functions.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
         IConfiguration configuration)
    {
        var cosmosClient = new CosmosClient(
            configuration["Cosmos:Endpoint"],
            configuration["Cosmos:Key"]
        );

        services.AddSingleton(cosmosClient);
        services.AddScoped<ITaskItemRepository, CosmosTaskRepository>();

        return services;
    }
}
