using System;

namespace ProjectPlanner.Cqrs.Base.DDD.Domain
{
    public class AggregateRoot : Entity
    {
        public DateTime Version { get; private set; }

        public AggregateRoot()
        {
            Version = new DateTime(1753, 1, 1);
        }
    }
}
