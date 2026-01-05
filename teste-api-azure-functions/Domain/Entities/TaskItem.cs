using teste_api_azure_functions.Domain.Exceptions;

namespace teste_api_azure_functions.Domain.Entities;

public class TaskItem
{
    public Guid id { get; }
    public string title { get; private set; }
    public DateTime createdAt { get; }
    public DateTime? dueDate { get; private set; }
    public string? description { get; private set; }
    public bool isClosed { get; private set; }


    // constructor for creating new TaskItems
    public TaskItem(string title, DateTime? dueDate = null, string? description = null)
    {
        var now = DateTime.UtcNow;
        ValidateTitle(title);
        ValidateDueDate(now, dueDate);

        this.id = Guid.NewGuid();
        this.title = title;
        this.dueDate = dueDate;
        this.description = description;
        this.createdAt = now;
        this.isClosed = false;
    }


    // constructor used for restoring from persistence
    private TaskItem(
        Guid id,
        string title,
        DateTime? dueDate,
        DateTime createdAt,
        string? description,
        bool isClosed)
    {
        ValidateTitle(title);
        ValidateDueDate(createdAt, dueDate);

        this.id = id;
        this.title = title;
        this.description = description;
        this.createdAt = createdAt;
        this.dueDate = dueDate;
        this.isClosed = isClosed;
    }


    // factory method to restore from persistence
    public static TaskItem Restore(
        Guid id,
        string title,
        DateTime createdAt,
        bool isClosed,
        DateTime? dueDate = null,
        string? description = null)
    {
        return new TaskItem(id, title, dueDate, createdAt, description, isClosed);
    }

    public void UpdateTitle(string newTitle)
    {
        ValidateTitle(newTitle);
        this.title = newTitle;
    }

    public void UpdateDueDate(DateTime? newDueDate)
    {
        ValidateDueDate(this.createdAt, newDueDate);
        this.dueDate = newDueDate;
    }

    public void UpdateDescription(string? newDescription)
    {
        this.description = newDescription;
    }

    public void Close()
    {
        if (isClosed)
        {
            throw new DomainException("Task is already closed");
        }
        isClosed = true;
    }

    public void ReOpen()
    {
        if (!isClosed)
        {
            throw new DomainException("Task is already open");
        }
        isClosed = false;
    }

    private static void ValidateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Title is required");
    }

    private static void ValidateDueDate(DateTime creationDate, DateTime? dueDate = null)
    {
        if (dueDate.HasValue && dueDate.Value < creationDate)
        {
            throw new DomainException("Due date cannot be earlier than the creation date");
        }
    }
}
