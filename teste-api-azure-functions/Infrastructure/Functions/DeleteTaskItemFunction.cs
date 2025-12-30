using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace teste_api_azure_functions.Infrastructure.Functions;

public class DeleteTaskItemFunction
{
    private readonly ILogger<DeleteTaskItemFunction> _logger;

    public DeleteTaskItemFunction(ILogger<DeleteTaskItemFunction> logger)
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