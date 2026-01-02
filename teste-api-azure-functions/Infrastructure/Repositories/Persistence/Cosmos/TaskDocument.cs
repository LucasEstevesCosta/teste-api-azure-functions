using Newtonsoft.Json;

namespace teste_api_azure_functions.Infrastructure.Repositories.Persistence.Cosmos;

public class TaskDocument
{
    [JsonProperty("id")]
    public string id { get; set; } = default!;

    public string title { get; set; } = default!;
    public string? description { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime? dueDate { get; set; }
    public bool isClosed { get; set; }
}