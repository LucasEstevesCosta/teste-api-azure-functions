using teste_api_azure_functions.Domain.Entities;

namespace teste_api_azure_functions.Application.DTOs.TaskItems
{
    public class ShowTaskItemDTO
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? dueDate { get; set; }
        public string? description { get; set; }
        public bool? isClosed { get; set; }

        public ShowTaskItemDTO(TaskItem task)
        {
            id = task.id;
            title = task.title;
            createdAt = task.createdAt;
            dueDate = task.dueDate;
            description = task.description;
            isClosed = task.isClosed;
        }
    }
}
