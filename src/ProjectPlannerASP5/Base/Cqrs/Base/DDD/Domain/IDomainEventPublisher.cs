namespace ProjectPlannerASP5.Base.Cqrs.Base.DDD.Domain
{
    public interface IDomainEventPublisher
    {
        void Publish<T>(T domainEvent) where T : IDomainEvent;
    }
}