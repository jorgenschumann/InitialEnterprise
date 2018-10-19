using System.Collections.Generic;
using System.Linq;

namespace InitialEnterprise.Infrastructure.Utils
{
    public static class CollectionExtensions
    {
        public static bool IsNotNullOrEmpty<T>(this List<T> candidate)
        {
            return candidate != null && candidate.Any();
        }

        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> candidate)
        {
            return candidate != null && candidate.Any();
        }

        public static List<TTarget> ToTList<TSource, TTarget>(this IEnumerable<TSource> source)
        {
            var convertedList = new List<TTarget>();

            if (source.IsNotNullOrEmpty())
                convertedList = source.Cast<TTarget>().ToList();

            return convertedList;
        }
    }
 
}