namespace WebApplication3.Services
{
    public interface IMessageService
    {
        bool Enqueue(string message);
    }
}
