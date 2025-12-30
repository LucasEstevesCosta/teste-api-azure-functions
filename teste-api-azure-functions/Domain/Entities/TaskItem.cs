using teste_api_azure_functions.Domain.Exceptions;

namespace teste_api_azure_functions.Domain.Entities
{
    public class TaskItem
    {
        public Guid id { get; private set; }
        public string title { get; private set; }
        public string? createdAt { get; private set; }
        public string? dueDate { get; private set; }
        public string? description { get; private set; }
        public bool? isClosed { get; private set; } = false;

        public TaskItem(string title, string? dueDate, string? createdAt, string? description = "")
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new DomainException("Title cannot be empty.");
            }

            this.id = Guid.NewGuid();
            this.title = title;
            this.createdAt = createdAt;
            this.dueDate = dueDate;
            this.description = description;
        }

        public void closeTask()
        {
            this.isClosed = true;
        }

        public void openTask()
        {
            this.isClosed = false;
        }
    }
}
