using Microsoft.Extensions.DependencyInjection;
using teste_api_azure_functions.Application.Services.TaskItems;

namespace teste_api_azure_functions.Application.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        // TaskItem use cases
        services.AddScoped<CreateTaskItemService>();
        services.AddScoped<UpdateTaskItemService>();
        services.AddScoped<DeleteTaskItemService>();
        services.AddScoped<GetAllTaskItemsService>();
        services.AddScoped<GetTaskItemByIdService>();

        return services;
    }
}
