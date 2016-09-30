using OnlineStore.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.Common.Caching
{
    public class CacheProvider : ICacheProvider
    {
        // memory cache instance si
        private readonly System.Runtime.Caching.MemoryCache _cache = System.Runtime.Caching.MemoryCache.Default;


        public T Get<T>(string key)
        {
            System.Diagnostics.Contracts.Contract.Assert(!string.IsNullOrEmpty(key));

            return (T)_cache.Get(key);
        }

        public bool IsExist(string key)
        {
            System.Diagnostics.Contracts.Contract.Assert(!string.IsNullOrEmpty(key));

            return _cache.Any(i => i.Key == key);
        }

        public void Remove(string key)
        {
            System.Diagnostics.Contracts.Contract.Assert(!string.IsNullOrEmpty(key));

            _cache.Remove(key);
        }

        public void Set(string key, object value, int expiredMinute)
        {
            System.Diagnostics.Contracts.Contract.Assert(!string.IsNullOrEmpty(key));
            System.Diagnostics.Contracts.Contract.Assert(value != null);
            System.Diagnostics.Contracts.Contract.Assert(expiredMinute > 0);

            if (IsExist(key))
            {
                Remove(key);
            }

            _cache.Add(key, value, DateTimeOffset.Now.AddMinutes(expiredMinute));
        }
    }
}
