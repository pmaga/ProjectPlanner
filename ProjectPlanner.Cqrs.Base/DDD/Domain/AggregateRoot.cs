using System;
using ProjectPlanner.Cqrs.Base.DDD.Domain.Annotations;

namespace ProjectPlanner.Cqrs.Base.DDD.Domain
{
    [DomainAggregateRoot]
    public abstract class AggregateRoot : Entity
    {
        private IDomainEventPublisher _eventPublisher;

        protected internal virtual IDomainEventPublisher EventPublisher
        {
            get { return _eventPublisher; }
            set
            {
                if (_eventPublisher != null)
                {
                    throw new InvalidOperationException("Publisher is already set!");
                }
                _eventPublisher = value;
            }
        }
        public DateTime Version { get; private set; }

        protected AggregateRoot()
        {
            Version = new DateTime(1753, 1, 1);
        }
    }
}
