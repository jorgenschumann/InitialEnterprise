using System.Collections.Generic;
using SeedPacket.Extensions;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

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

            return SeedDataCache.FromCache(typeName, () => Load<IEnumerable<TType>>(typeName));
        }

        private static TType Load<TType>(string typeName)
        {
            var directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var fileContent = File.ReadAllText( $"{directory}\\{typeName}");

            return JsonConvert.DeserializeObject<TType>(fileContent);
        }

        public static TType BuildTypeFromFile<TType>()
        {        
            return BuildTypeCollection<TType>(1).FirstOrDefault();
        }
    }
}