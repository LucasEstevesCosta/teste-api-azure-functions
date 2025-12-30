using teste_api_azure_functions.Domain.Entities;

namespace teste_api_azure_functions.Domain.Interfaces
{
    public interface ITaskItemRepository
    {
        Task AddAsync(TaskItem taskItem);
        Task UpdateAsync(TaskItem taskItem);
        Task DeleteAsync(Guid id);

        Task<TaskItem?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<TaskItem>> GetAllAsync();
    }
}
