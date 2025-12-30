using teste_api_azure_functions.Domain.Entities;
using teste_api_azure_functions.Domain.Interfaces;

namespace teste_api_azure_functions.Application.Services.TaskItems
{
    public class UpdateTaskItemService
    {
        private readonly ITaskItemRepository _repository;

        public UpdateTaskItemService(ITaskItemRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(TaskItem taskItem)
        {
            await _repository.UpdateAsync(taskItem);
        }
    }
}
