namespace teste_api_azure_functions.Domain.Interfaces
{
    public interface IClock
    {
        DateTime UtcNow { get; }
    }
}
