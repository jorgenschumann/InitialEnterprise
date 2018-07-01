using System;

namespace InitialEnterprise.Infrastructure.DDD.Domain
{
    public class AuditTrail
    {
        public Guid UserId { get; set; }

        public DateTime DateTime { get; set; }
    }
}