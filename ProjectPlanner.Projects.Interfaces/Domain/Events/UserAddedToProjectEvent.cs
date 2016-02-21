using System;
using ProjectPlanner.Cqrs.Base.DDD.Domain;

namespace ProjectPlanner.Projects.Interfaces.Domain.Events
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