using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlanner.CRM.Domain;
using ProjectPlanner.CRM.Interfaces.Application.Commands;
using ProjectPlanner.CRM.Interfaces.Domain.Exceptions;

namespace ProjectPlanner.CRM.Application.Commands.Handlers
{
    public class DeleteClientCommandHandler : ICommandHandler<DeleteClientCommand>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void Handle(DeleteClientCommand command)
        {
            var storedClient = _clientRepository.Load(command.ClientId);
            if (storedClient == null)
            {
                throw new ClientOperationException($"Cannot found client: {command.ClientId}");
            }

            _clientRepository.Delete(storedClient.Id);
        }
    }
}