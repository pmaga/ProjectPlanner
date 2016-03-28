using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlanner.CRM.Domain;
using ProjectPlanner.CRM.Interfaces.Application.Commands;

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
            _clientRepository.Delete(command.ClientId);
        }
    }
}