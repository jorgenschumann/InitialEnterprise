using System;
using System.Collections.Generic;

namespace InitialEnterprise.Infrastructure.Misc
{
    public static class ReflectionUtils
    {
        public static Type[] GetAllDerivedTypes(this AppDomain appDomain, Type[] selectedTypes)
        {
            var result = new List<Type>();
            var assemblies = appDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    foreach (var item in selectedTypes)
                    {
                        if (type.IsSubclassOf(item))
                            result.Add(type);
                    }
                }
            }
            return result.ToArray();
        }
    }
}