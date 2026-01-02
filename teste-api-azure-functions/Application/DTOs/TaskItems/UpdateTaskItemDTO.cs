namespace teste_api_azure_functions.Application.DTOs.TaskItems;

public class UpdateTaskItemDTO
{
    public Guid id { get; set; }
    public string? title { get; set; }
    public DateTime? createdAt { get; set; }
    public DateTime? dueDate { get; set; }
    public string? description { get; set; }
    public bool? isClosed { get; set; } = false;
}
