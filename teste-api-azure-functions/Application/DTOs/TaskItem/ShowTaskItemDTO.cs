namespace teste_api_azure_functions.Application.DTOs.TaskItem
{
    public class ShowTaskItemDTO
    {
        public Guid id { get; set; }
        public required string title { get; set; }
        public string? createdAt { get; set; }
        public string? dueDate { get; set; }
        public string? description { get; set; }
        public bool? isClosed { get; set; }
    }
}
