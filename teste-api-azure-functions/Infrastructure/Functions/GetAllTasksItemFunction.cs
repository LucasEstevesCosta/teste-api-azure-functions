using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using teste_api_azure_functions.Application.Services.TaskItems;

namespace teste_api_azure_functions.Infrastructure.Functions;

public class GetAllTasksItemFunction
{
    private readonly GetAllTaskItemsService _service;

    public GetAllTasksItemFunction(GetAllTaskItemsService service)
    {
        _service = service;
    }

    [Function("GetTasks")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "tasks")] HttpRequestData req)
    {
        var taskItems = await _service.ExecuteAsync();

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(taskItems);

        return response;
    }
}