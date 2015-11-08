using System;
using ProjectPlanner.Cqrs.Base.DDD.Domain.Annotations;

namespace ProjectPlanner.Cqrs.Base.DDD.Domain
{
    [DomainAggregateRoot]
    public class AggregateRoot : Entity
    {
        public DateTime Version { get; private set; }

        public AggregateRoot()
        {
            Version = new DateTime(1753, 1, 1);
        }
    }
}
