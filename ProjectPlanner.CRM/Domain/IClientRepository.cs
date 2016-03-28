namespace ProjectPlanner.CRM.Domain
{
    public interface IClientRepository
    {
        Client FindByCode(string code);
        Client Load(int clientId);

        void Save(Client client);
        void Delete(int entityId);
    }
}