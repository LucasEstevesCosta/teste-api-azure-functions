using teste_api_azure_functions.Domain.Entities;
using teste_api_azure_functions.Domain.Interfaces;

namespace teste_api_azure_functions.Application.Services.TaskItems
{
    internal class GetTaskItemByIdService
    {
        private readonly ITaskItemRepository _repository;

        public GetTaskItemByIdService(ITaskItemRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<TaskItem?> ExecuteAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
