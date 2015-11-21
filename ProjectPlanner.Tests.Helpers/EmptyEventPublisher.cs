using ProjectPlanner.Cqrs.Base.DDD.Domain;

namespace ProjectPlanner.Tests.Helpers
{
    public sealed class EmptyEventPublisher : IDomainEventPublisher
    {
        public void Publish<T>(T domainEvent) where T : IDomainEvent
        {

        }
    }
}