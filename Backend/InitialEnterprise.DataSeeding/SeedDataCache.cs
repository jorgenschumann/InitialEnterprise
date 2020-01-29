using System;
using Microsoft.Extensions.Caching.Memory;

namespace InitialEnterprise.Shared.DataSeeding
{
    static class SeedDataCache
    {
        static readonly MemoryCache cache = new MemoryCache(new MemoryCacheOptions());

        public static TType FromCache<TType>(string key, Func<TType> aquire)
        {
            var cachedItem = (TType)cache.Get(key);

            if (cachedItem == null)
            {
                cachedItem = aquire();
                cache.Set(key, cachedItem);
            }
            return cachedItem;
        }

    }
}