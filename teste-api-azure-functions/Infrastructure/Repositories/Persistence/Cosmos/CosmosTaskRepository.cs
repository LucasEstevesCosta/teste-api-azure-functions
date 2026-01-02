using Microsoft.Azure.Cosmos;
using teste_api_azure_functions.Domain.Entities;
using teste_api_azure_functions.Domain.Interfaces;

namespace teste_api_azure_functions.Infrastructure.Repositories.Persistence.Cosmos;

public class CosmosTaskRepository : ITaskItemRepository
{
    private readonly Container _container;

    public CosmosTaskRepository(CosmosClient client)
    {
        _container = client.GetContainer("taskdb", "tasks");
    }

    public async Task AddAsync(TaskItem task)
    {
        var document = TaskMapper.ToDocument(task);

        await _container.CreateItemAsync(
            document,
            new PartitionKey(document.id)
        );
    }

    public async Task<IReadOnlyList<TaskItem>> GetAllAsync()
    {
        var query = _container.GetItemQueryIterator<TaskDocument>(
            new QueryDefinition("SELECT * FROM c")
        );

        var results = new List<TaskItem>();

        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();

            foreach (var doc in response)
            {
                results.Add(TaskMapper.ToEntity(doc));
            }
        }

        return results;
    }

    public async Task<TaskItem?> GetByIdAsync(Guid id)
    {
        try
        {
            var response = await _container.ReadItemAsync<TaskDocument>(
                id.ToString(),
                new PartitionKey(id.ToString())
            );

            return TaskMapper.ToEntity(response.Resource);
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
    }

    public async Task UpdateAsync(TaskItem task)
    {
        var document = TaskMapper.ToDocument(task);

        await _container.UpsertItemAsync(
            document,
            new PartitionKey(document.id)
        );
    }

    public async Task DeleteAsync(Guid id)
    {
        await _container.DeleteItemAsync<TaskDocument>(
            id.ToString(),
            new PartitionKey(id.ToString())
        );
    }
}