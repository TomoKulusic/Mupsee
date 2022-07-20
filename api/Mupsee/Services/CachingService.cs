using Microsoft.Extensions.Caching.Memory;
using Mupsee.Interfaces;

namespace Mupsee.Services
{
    public class CachingService<T> : ICachingService<T> where T : class
    {
        private IMemoryCache _memoryCache;

        public CachingService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <inheritdoc/>

        public T CheckIfDataIsCached(string name)
        {
            return _memoryCache.Get<T>(name);
        }

        /// <inheritdoc/>
        public void CacheData(string name, T data)
        {
            var output = _memoryCache.Get<List<T>>(name);

            if (output is null)
            {
                _memoryCache.Set(name, data, TimeSpan.FromDays(1));
            }
        }
    }
}
