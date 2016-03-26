using ProjectPlanner.Cqrs.Base.Infrastructure.Attributes;

namespace ProjectPlanner.Cqrs.Base.DDD.Domain.Helpers
{
    [Component]
    public class InjectorHelper
    {
        public IDomainEventPublisher EventPublisher { get; set; }

        public InjectorHelper(IDomainEventPublisher  eventPublisher)
        {
            EventPublisher = eventPublisher;
        }

        public void InjectDependencies(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot != null && aggregateRoot.EventPublisher == null)
            {
                aggregateRoot.EventPublisher = EventPublisher;
            }
        }
    }
}