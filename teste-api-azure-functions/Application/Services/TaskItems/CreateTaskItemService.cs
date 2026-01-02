using teste_api_azure_functions.Application.DTOs.TaskItems;
using teste_api_azure_functions.Domain.Entities;
using teste_api_azure_functions.Domain.Interfaces;

namespace teste_api_azure_functions.Application.Services.TaskItems;

public class CreateTaskItemService
{
    private readonly ITaskItemRepository _repository;
    
    public CreateTaskItemService(ITaskItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<ShowTaskItemDTO> ExecuteAsync(CreateTaskItemDTO dto)
    {
        var taskItem = new TaskItem(
            dto.title,
            dto.dueDate,
            dto.description
        );

        await _repository.AddAsync(taskItem);

        return new ShowTaskItemDTO(taskItem);
    }
}
