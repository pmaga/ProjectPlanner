using System.Linq;

namespace ProjectPlanner.CRM.Interfaces.Presentation
{
    public interface IClientFinder
    {
        IQueryable<ClientListDto> FindClients();
        IQueryable<ClientLookup> GetLookups();
        ClientEditDto GetClient(string clientCode);
    }
}