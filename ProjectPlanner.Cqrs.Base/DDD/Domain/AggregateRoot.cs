using System;
using ProjectPlanner.Cqrs.Base.DDD.Domain.Annotations;

namespace ProjectPlanner.Cqrs.Base.DDD.Domain
{
    [DomainAggregateRoot]
    public abstract class AggregateRoot : Entity
    {
        public DateTime Version { get; private set; }

        protected AggregateRoot()
        {
            Version = new DateTime(1753, 1, 1);
        }
    }
}
