using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Services.Contracts
{
    public interface ICacheService
    {
        Task Add(string key, object value);
        Task<object> Get(string key);
    }
}
