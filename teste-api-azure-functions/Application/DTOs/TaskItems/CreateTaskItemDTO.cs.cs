namespace teste_api_azure_functions.Application.DTOs.TaskItems;

public class CreateTaskItemDTO
{
    public required string title { get; set; }
    public DateTime? dueDate { get; set; }
    public string? description { get; set; }
}
