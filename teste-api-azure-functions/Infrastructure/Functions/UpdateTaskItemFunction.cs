using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace teste_api_azure_functions.Infrastructure.Functions;

public class UpdateTaskItemFunction
{
    private readonly ILogger<UpdateTaskItemFunction> _logger;

    public UpdateTaskItemFunction(ILogger<UpdateTaskItemFunction> logger)
    {
        _logger = logger;
    }

    [Function("Function")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}