using Microsoft.Extensions.Caching.Memory;
using Mupsee.Interfaces;

namespace Mupsee.Services
{
    public class CachingService<T> : ICachingService<T> where T : class
    {
        private IMemoryCache _cache;

        public CachingService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T CheckIfDataIsCached(string name)
        {
            return _cache.Get<T>(name);
        }

        public void CacheData(string name, T data)
        {
            var output = _cache.Get<List<T>>(name);

            if (output is null)
            {
                _cache.Set(name, data, TimeSpan.FromDays(1));
            }
        }
    }
}
