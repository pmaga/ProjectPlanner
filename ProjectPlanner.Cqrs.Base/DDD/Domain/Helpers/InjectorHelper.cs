using ProjectPlanner.Cqrs.Base.Infrastructure.Attributes;

namespace ProjectPlanner.Cqrs.Base.DDD.Domain.Helpers
{
    [Component]
    public class InjectorHelper
    {
        public IDomainEventPublisher EventPublisher { get; set; }

        public void InjectDependencies(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot != null)
            {
                aggregateRoot.EventPublisher = EventPublisher;
            }
        }
    }
}