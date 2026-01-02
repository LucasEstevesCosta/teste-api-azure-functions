using teste_api_azure_functions.Domain.Interfaces;

namespace teste_api_azure_functions.Application.Services.TaskItems;

public class DeleteTaskItemService
{
    private readonly ITaskItemRepository _repository;

    public DeleteTaskItemService(ITaskItemRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
