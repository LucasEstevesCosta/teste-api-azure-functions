using teste_api_azure_functions.Domain.Entities;

namespace teste_api_azure_functions.Infrastructure.Repositories.Persistence.Cosmos;

public static class TaskMapper
{
    public static TaskDocument ToDocument(TaskItem task)
        => new()
        {
            id = task.id.ToString(),
            title = task.title,
            createdAt = task.createdAt,
            isClosed = task.isClosed,
            dueDate = task.dueDate,
            description = task.description
        };

    public static TaskItem ToEntity(TaskDocument doc)
        => TaskItem.Restore(
            Guid.Parse(doc.id),
            doc.title,
            doc.createdAt,
            doc.isClosed,
            doc.dueDate,
            doc.description
        );
}