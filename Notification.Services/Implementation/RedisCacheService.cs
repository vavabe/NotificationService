using Notification.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Services.Implementation
{
    public class RedisCacheService : ICacheService
    {
        public Task Add(string key, object value)
        {
            throw new NotImplementedException();
        }

        public Task<object> Get(string key)
        {
            throw new NotImplementedException();
        }
    }
}
