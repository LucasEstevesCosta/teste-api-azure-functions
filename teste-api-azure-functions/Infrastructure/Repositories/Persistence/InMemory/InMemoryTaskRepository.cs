using teste_api_azure_functions.Domain.Entities;
using teste_api_azure_functions.Domain.Interfaces;

namespace teste_api_azure_functions.Infrastructure.Repositories.Persistence.InMemory;

public class InMemoryTaskItemRepository : ITaskItemRepository
{
    private static readonly List<TaskItem> _tasks = new();

    public Task AddAsync(TaskItem taskItem)
    {
        _tasks.Add(taskItem);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(TaskItem taskItem)
    {
        var index = _tasks.FindIndex(t => t.id == taskItem.id);

        if (index == -1)
            return Task.CompletedTask;

        _tasks[index] = taskItem;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.id == id);

        if (task != null)
            _tasks.Remove(task);

        return Task.CompletedTask;
    }

    public Task<TaskItem?> GetByIdAsync(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.id == id);
        return Task.FromResult(task);
    }

    public Task<IReadOnlyList<TaskItem>> GetAllAsync()
    {
        return Task.FromResult((IReadOnlyList<TaskItem>)_tasks.AsReadOnly());
    }
}
