using teste_api_azure_functions.Domain.Entities;

namespace teste_api_azure_functions.Infrastructure.Repositories.Persistence.Cosmos;

public static class TaskMapper
{
    public static TaskDocument ToDocument(TaskItem task)
        => new()
        {
            id = task.id.ToString(),
            title = task.title,
            dueDate = task.dueDate,
            createdAt = task.createdAt,
            description = task.description,
            isClosed = task.isClosed
        };

    public static TaskItem ToEntity(TaskDocument doc)
        => TaskItem.Restore(
            Guid.Parse(doc.id),
            doc.title,
            doc.dueDate,
            doc.createdAt,
            doc.description,
            doc.isClosed
        );
}