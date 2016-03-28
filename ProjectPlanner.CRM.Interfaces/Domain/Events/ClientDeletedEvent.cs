using ProjectPlanner.Cqrs.Base.DDD.Domain;

namespace ProjectPlanner.CRM.Interfaces.Domain.Events
{
    public class ClientDeletedEvent : IDomainEvent
    {
        public int ClientId { get; set; }

        public ClientDeletedEvent(int clientId)
        {
            ClientId = clientId;
        }
    }
}