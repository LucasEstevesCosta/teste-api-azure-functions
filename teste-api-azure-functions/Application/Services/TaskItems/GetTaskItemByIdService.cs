using teste_api_azure_functions.Application.DTOs.TaskItems;
using teste_api_azure_functions.Domain.Entities;
using teste_api_azure_functions.Domain.Interfaces;

namespace teste_api_azure_functions.Application.Services.TaskItems;

public class GetTaskItemByIdService
{
    private readonly ITaskItemRepository _repository;

    public GetTaskItemByIdService(ITaskItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<ShowTaskItemDTO?> ExecuteAsync(Guid id)
    {
        TaskItem? taskItem = await _repository.GetByIdAsync(id);

        if (taskItem == null)
        {
            return null;
        }

        ShowTaskItemDTO result = new(taskItem);

        return result;
    }
}
