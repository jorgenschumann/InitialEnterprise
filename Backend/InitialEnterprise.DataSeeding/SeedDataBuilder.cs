using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace InitialEnterprise.Shared.DataSeeding
{
    public static class SeedDataBuilder
    {
        public static TType BuildType<TType>()
        {
            return BuildTypeCollectionFromFile<TType>().FirstOrDefault();
        }
     
        public static IEnumerable<TType> BuildTypeCollectionFromFile<TType>()
        {
            var typeName = $"{typeof(TType).Name}.json";

            return SeedDataCache.FromCache(typeName, () => Load<IEnumerable<TType>>(typeName));
        }

        private static TType Load<TType>(string typeName)
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var fileContent = File.ReadAllText($"{directory}\\{typeName}");

            return JsonConvert.DeserializeObject<TType>(fileContent);
        }
    }
}