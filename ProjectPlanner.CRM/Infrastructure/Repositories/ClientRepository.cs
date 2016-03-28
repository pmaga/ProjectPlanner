using System.Linq;
using NHibernate.Linq;
using ProjectPlanner.Cqrs.Base.DDD.Domain;
using ProjectPlanner.Cqrs.Base.DDD.Domain.Annotations;
using ProjectPlanner.Cqrs.Base.DDD.Domain.Helpers;
using ProjectPlanner.CRM.Domain;
using ProjectPlanner.CRM.Interfaces.Domain.Events;
using ProjectPlanner.Infrastructure.Orm;
using ProjectPlanner.Infrastructure.Orm.Repositories;

namespace ProjectPlanner.CRM.Infrastructure.Repositories
{
    [DomainRepository]
    public class ClientRepository : RepositoryForBaseEntity<Client>, IClientRepository
    {
        private readonly IDomainEventPublisher _domainEventPublisher;

        public ClientRepository(IEntityManager entityManager, InjectorHelper injectorHelper, IDomainEventPublisher domainEventPublisher) 
            : base(entityManager, injectorHelper)
        {
            _domainEventPublisher = domainEventPublisher;
        }

        public Client FindByCode(string code)
        {
            return EntityManager.CurrentSession.Query<Client>()
                .FirstOrDefault(n => n.Code == code);
        }

        public override void Save(Client client)
        {
            var isNewEntity = client.Id == 0;

            base.Save(client);

            if (isNewEntity)
            {
                _domainEventPublisher.Publish(new ClientCreatedEvent(client.Id));
            }
        }

        public override void Delete(int id)
        {
            base.Delete(id);
            EntityManager.CurrentSession.Flush();

            _domainEventPublisher.Publish(new ClientDeletedEvent(id));
        }
    }
}