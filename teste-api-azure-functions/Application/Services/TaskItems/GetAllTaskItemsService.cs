using teste_api_azure_functions.Application.DTOs.TaskItems;
using teste_api_azure_functions.Domain.Entities;
using teste_api_azure_functions.Domain.Interfaces;

namespace teste_api_azure_functions.Application.Services.TaskItems;

public class GetAllTaskItemsService
{
    private readonly ITaskItemRepository _repository;

    public GetAllTaskItemsService(ITaskItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<ShowTaskItemDTO>> ExecuteAsync()
    {

        var taskItems = await _repository.GetAllAsync();
        var result = new List<ShowTaskItemDTO>();

        foreach (TaskItem task in taskItems)
        {
            var taskDTO = new ShowTaskItemDTO(task);
            result.Add(taskDTO);
        }

        return result;
    }
}
