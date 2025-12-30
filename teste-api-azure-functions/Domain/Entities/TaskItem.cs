using teste_api_azure_functions.Domain.Exceptions;

namespace teste_api_azure_functions.Domain.Entities
{
    public class TaskItem
    {
        public Guid id { get; private set; }
        public string title { get; private set; }
        public DateTime createdAt { get; private set; }
        public DateTime? dueDate { get; private set; }
        public string? description { get; private set; }
        public bool isClosed { get; private set; }

        public TaskItem(string title, DateTime? dueDate, string? description)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException("Title cannot be empty.");

            id = Guid.NewGuid();
            this.title = title;
            this.dueDate = dueDate;
            this.description = description;
            createdAt = DateTime.UtcNow;
            isClosed = false;
        }

        public void Close() => isClosed = true;
        public void Open() => isClosed = false;
    }

}
