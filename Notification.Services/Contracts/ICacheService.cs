using System.Threading.Tasks;

namespace Notification.Services.Contracts
{
    public interface ICacheService
    {
        Task<T> Add<T>(string key, T value);
        Task<T> Get<T>(string key);
    }
}
