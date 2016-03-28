using System.Linq;
using NHibernate.Linq;
using ProjectPlanner.Cqrs.Base.CQRS.Query.Attributes;
using ProjectPlanner.CRM.Domain;
using ProjectPlanner.CRM.Interfaces.Presentation;
using ProjectPlanner.Infrastructure.Orm;

namespace ProjectPlanner.CRM.Presentation.Implementation
{
    [Finder]
    public class ClientFinder : IClientFinder
    {
        private readonly IEntityManager _entityManager;

        public ClientFinder(IEntityManager entityManager)
        {
            _entityManager = entityManager;
        }

        public IQueryable<ClientListDto> FindClients()
        {
            return GetClients()
                .Select(n => new ClientListDto(n.Id, n.Code, n.Name, n.Status)
                {
                    CreateTimeStamp = n.CreateTimeStamp,
                    LastUpdateTimeStamp = n.LastUpdateTimeStamp
                });
        }

        public IQueryable<ClientLookup> GetLookups()
        {
            return GetClients()
                .Select(n => new ClientLookup(n.Id, n.Code, n.Name));
        }

        public ClientEditDto GetClient(string clientCode)
        {
            var client = GetClients()
                .SingleOrDefault(n => n.Code == clientCode);

            return client == null
                ? null
                : new ClientEditDto
                {
                    Id = client.Id,
                    Code = client.Code,
                    Name = client.Name,
                    Phone = client.Phone,
                    EmailAddress = client.EmailAddress,
                    Status = client.Status,
                    CreateTimeStamp = client.CreateTimeStamp,
                    LastUpdateTimeStamp = client.LastUpdateTimeStamp
                };
        }

        private IQueryable<Client> GetClients()
        {
            return _entityManager.CurrentSession.Query<Client>();
        }
    }
}