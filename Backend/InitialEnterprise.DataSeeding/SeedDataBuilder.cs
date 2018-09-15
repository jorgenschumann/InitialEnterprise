using System.Collections.Generic;
using SeedPacket.Extensions;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System;
using Microsoft.Extensions.Caching.Memory;

namespace InitialEnterpriseTests.DataSeeding
{      
    public static class SeedDataBuilder
    {   
        public static TType BuildType<TType>()
        {
            return BuildTypeCollectionFromFile<TType>().FirstOrDefault();
        }

        public static IEnumerable<TType> BuildTypeCollection<TType>(int count)
        {
            return new List<TType>().Seed(count);
        }

        public static IEnumerable<TType> BuildTypeCollectionFromFile<TType>()
        {
            var typeName = $"{typeof(TType).Name}.json";

            return Caching.FromCache(typeName, () => Load<IEnumerable<TType>>(typeName));
        }

        private static TType Load<TType>(string typeName)
        {
            var fileContent = File.ReadAllText(typeName);

            return JsonConvert.DeserializeObject<TType>(fileContent);
        }

        public static TType BuildTypeFromFile<TType>()
        {        
            return BuildTypeCollection<TType>(1).FirstOrDefault();
        }

        private static class Caching
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
}