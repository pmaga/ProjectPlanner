using System;
using ProjectPlanner.Cqrs.Base.DDD.Domain;

namespace ProjectPlanner.Projects.Interfaces.Domain.Events
{
    public class UserRemovedFromProjectEvent : IDomainEvent
    {
        public Guid UserId { get; set; }

        public UserRemovedFromProjectEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}