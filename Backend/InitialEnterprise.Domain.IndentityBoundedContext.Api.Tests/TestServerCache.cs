using Microsoft.Extensions.Caching.Memory;
using System;

namespace InitialEnterprise.Domain.IndentityBoundedContext.Api.Tests
{
    internal static class TestServerCache
    {
        private static readonly MemoryCache serverCache = new MemoryCache(new MemoryCacheOptions());

        public static TType FromCache<TType>(string key, Func<TType> aquire)
        {
            var cachedItem = (TType)serverCache.Get(key);

            if (cachedItem == null)
            {
                cachedItem = aquire();
                serverCache.Set(key, cachedItem);
            }
            return cachedItem;
        }
    }
}