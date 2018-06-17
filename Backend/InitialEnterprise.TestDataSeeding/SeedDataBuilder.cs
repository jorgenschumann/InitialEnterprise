using System.Collections.Generic;
using SeedPacket.Extensions;

namespace InitialEnterprise.TestDataSeeding
{
    public class SeedDataBuilder
    {
        public static IEnumerable<TEntity> BuildEntities<TEntity>(int count)
        {
            return new List<TEntity>().Seed(count);
        }
    }
}
