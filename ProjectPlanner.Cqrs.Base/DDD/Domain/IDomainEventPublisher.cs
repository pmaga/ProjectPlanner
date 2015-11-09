﻿namespace ProjectPlanner.Cqrs.Base.DDD.Domain
{
    public interface IDomainEventPublisher
    {
        void Publish<T>(T domainEvent) where T : IDomainEvent;
    }
}