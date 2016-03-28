using ProjectPlanner.Cqrs.Base.DDD.Domain.Helpers;
using ProjectPlanner.CRM.Interfaces.Domain.Exceptions;

namespace ProjectPlanner.CRM.Domain
{
    public class ClientFactory
    {
        private readonly IClientRepository _clientRepository;
        private readonly InjectorHelper _injectorHelper;

        public ClientFactory(IClientRepository clientRepository, InjectorHelper injectorHelper)
        {
            _clientRepository = clientRepository;
            _injectorHelper = injectorHelper;
        }

        public Client CreateClient(string code, string name, string phone, string emailAddress = null)
        {
            CheckIfClientWithSameCodeExists(code);

            var client = new Client(code, name, phone, emailAddress);
            _injectorHelper.InjectDependencies(client);

            return client;
        }

        private void CheckIfClientWithSameCodeExists(string code)
        {
            var storedClient = _clientRepository.FindByCode(code);

            if (storedClient != null)
            {
                throw new ClientOperationException($"Client with given code: {code} already exists!");
            }
        }
    }
}