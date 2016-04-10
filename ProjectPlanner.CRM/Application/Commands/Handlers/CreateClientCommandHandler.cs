using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlanner.CRM.Domain;
using ProjectPlanner.CRM.Interfaces.Application.Commands;

namespace ProjectPlanner.CRM.Application.Commands.Handlers
{
    public class CreateClientCommandHandler : ICommandHandler<CreateClientCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly ClientFactory _clientFactory;

        public CreateClientCommandHandler(IClientRepository clientRepository, ClientFactory clientFactory)
        {
            _clientRepository = clientRepository;
            _clientFactory = clientFactory;
        }

        public void Handle(CreateClientCommand command)
        {
            var client = _clientFactory.CreateClient(command.Type, command.Code, command.Name,
                command.Phone, command.EmailAddress);

            _clientRepository.Save(client);
            command.ClientId = client.Id;
        }
    }
}