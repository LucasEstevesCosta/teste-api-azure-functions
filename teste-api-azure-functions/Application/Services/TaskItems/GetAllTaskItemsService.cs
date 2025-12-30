using teste_api_azure_functions.Domain.Entities;
using teste_api_azure_functions.Domain.Interfaces;

namespace teste_api_azure_functions.Application.Services.TaskItems
{
    internal class GetAllTaskItemsService
    {
        private readonly ITaskItemRepository _repository;

        public GetAllTaskItemsService(ITaskItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<TaskItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
