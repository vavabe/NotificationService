namespace Notification.Services.Contracts
{
    public interface ICacheService
    {
        T Add<T>(string key, T value);
        T Get<T>(string key);
    }
}
