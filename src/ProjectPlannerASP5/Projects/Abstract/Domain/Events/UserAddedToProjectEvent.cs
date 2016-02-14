using System;
using ProjectPlannerASP5.Base.Cqrs.Base.DDD.Domain;

namespace ProjectPlannerASP5.Projects.Abstract.Domain.Events
{
    public class UserAddedToProjectEvent : IDomainEvent
    {
        public Guid UserId { get; set; }

        public UserAddedToProjectEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}