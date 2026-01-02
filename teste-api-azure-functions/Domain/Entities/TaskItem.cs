using teste_api_azure_functions.Domain.Exceptions;

namespace teste_api_azure_functions.Domain.Entities;

public class TaskItem
{
    public Guid id { get; }
    public string title { get; }
    public string? description { get; }
    public DateTime createdAt { get; }
    public DateTime? dueDate { get; }
    public bool isClosed { get; private set; }


    public TaskItem(string title, DateTime? dueDate, string? description)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Title is required");

        this.id = Guid.NewGuid();
        this.title = title;
        this.dueDate = dueDate;
        this.description = description;
        this.createdAt = DateTime.UtcNow;
        this.isClosed = false;
    }


    private TaskItem(
        Guid id,
        string title,
        DateTime? dueDate,
        DateTime createdAt,
        string? description,
        bool isClosed)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.createdAt = createdAt;
        this.dueDate = dueDate;
        this.isClosed = isClosed;
    }


    public static TaskItem Restore(
        Guid id,
        string title,
        DateTime? dueDate,
        DateTime createdAt,
        string? description,
        bool isClosed)
    {
        return new TaskItem(id, title, dueDate, createdAt, description, isClosed);
    }


    public void Close()
    {
        isClosed = true;
    }
}
