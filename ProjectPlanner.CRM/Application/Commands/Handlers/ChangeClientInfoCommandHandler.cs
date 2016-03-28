using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlanner.CRM.Domain;
using ProjectPlanner.CRM.Interfaces.Application.Commands;
using ProjectPlanner.CRM.Interfaces.Domain.Exceptions;

namespace ProjectPlanner.CRM.Application.Commands.Handlers
{
    public class ChangeClientInfoCommandHandler : ICommandHandler<ChangeClientInfoCommand>
    {
        private readonly IClientRepository _clientRepository;

        public ChangeClientInfoCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void Handle(ChangeClientInfoCommand command)
        {
            var client = _clientRepository.FindByCode(command.ClientCode);

            if (client == null)
            {
                throw new ClientOperationException($"Client with given code: {command.ClientCode} doesnt exists!");
            }

            client.ChangeBasicInfo(command.Name, command.Phone, command.EmailAddress);
            _clientRepository.Save(client);
        }
    }
}