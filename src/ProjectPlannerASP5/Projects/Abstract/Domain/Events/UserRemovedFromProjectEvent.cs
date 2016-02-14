using System;
using ProjectPlannerASP5.Base.Cqrs.Base.DDD.Domain;

namespace ProjectPlannerASP5.Projects.Abstract.Domain.Events
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