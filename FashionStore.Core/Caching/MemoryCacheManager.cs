using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Core.Caching
{
    public class MemoryCacheManager : ICacheManager
    {
        public ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        public T Get<T>(string key) where T : class
        {
            return Cache[key] as T;
        }
    }
}
