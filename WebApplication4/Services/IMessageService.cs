namespace WebApplication3.Services
{
    public interface IMessageService
    {
        Task<bool> SendAsync(string message, Guid channelId);
        Task<IEnumerable<string>> ReceiveFromChannel(Guid channelId);
        Task Initialization { get; }
    }
}
