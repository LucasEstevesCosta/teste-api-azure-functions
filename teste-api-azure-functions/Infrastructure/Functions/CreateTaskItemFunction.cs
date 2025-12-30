using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using System.Text.Json;
using teste_api_azure_functions.Application.DTOs.TaskItems;
using teste_api_azure_functions.Application.Services.TaskItems;

namespace teste_api_azure_functions.Infrastructure.Functions;

public class CreateTaskItemFunction
{
    private readonly CreateTaskItemService _service;

    public CreateTaskItemFunction(CreateTaskItemService service)
    {
        _service = service;
    }

    [Function("CreateTask")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "task")] HttpRequestData req)
    {
        var body = await JsonSerializer.DeserializeAsync<CreateTaskItemDTO>(req.Body);

        if (body == null)
        {
            return req.CreateResponse(HttpStatusCode.BadRequest);
        }

        var result = await _service.ExecuteAsync(body);

        var response = req.CreateResponse(HttpStatusCode.Created);
        await response.WriteAsJsonAsync(result);

        return response;
    }
}