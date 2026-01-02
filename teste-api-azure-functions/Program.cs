using Microsoft.Extensions.Hosting;
using teste_api_azure_functions.Application.DependencyInjection;
using teste_api_azure_functions.Infrastructure.DependencyInjection;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices((context, services) =>
    {
        var config = context.Configuration;

        services.AddApplicationServices();
        services.AddInfrastructure(config);

    })
    .Build();

host.Run();