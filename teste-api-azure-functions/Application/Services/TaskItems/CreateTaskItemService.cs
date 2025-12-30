using teste_api_azure_functions.Domain.Entities;
using teste_api_azure_functions.Domain.Interfaces;

namespace teste_api_azure_functions.Application.Services.TaskItems
{
    public class CreateTaskItemService
    {
        private readonly ITaskItemRepository _repository;
        
        public CreateTaskItemService(ITaskItemRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(TaskItem taskItem)
        {
            await _repository.AddAsync(taskItem);
        }
    }
}
