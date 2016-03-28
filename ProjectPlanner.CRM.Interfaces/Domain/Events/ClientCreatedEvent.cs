using ProjectPlanner.Cqrs.Base.DDD.Domain;

namespace ProjectPlanner.CRM.Interfaces.Domain.Events
{
    public class ClientCreatedEvent : IDomainEvent
    {
        public int CustomerId { get; set; }

        public ClientCreatedEvent(int customerId)
        {
            CustomerId = customerId;
        }
    }
}