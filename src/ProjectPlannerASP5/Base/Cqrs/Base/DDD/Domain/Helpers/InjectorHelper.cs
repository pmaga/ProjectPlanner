using ProjectPlannerASP5.Base.Cqrs.Base.Infrastructure.Attributes;

namespace ProjectPlannerASP5.Base.Cqrs.Base.DDD.Domain.Helpers
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
            if (aggregateRoot != null)
            {
                aggregateRoot.EventPublisher = EventPublisher;
            }
        }
    }
}