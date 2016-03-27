using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlanner.Projects.Domain;
using ProjectPlanner.Projects.Interfaces.Application.Commands;

namespace ProjectPlanner.Projects.Application.Commands.Handlers
{
    public class DeleteProjectCommandHandler : ICommandHandler<DeleteProjectCommand>
    {
        private readonly IProjectRepository _repository;

        public DeleteProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public void Handle(DeleteProjectCommand command)
        {
            _repository.Delete(command.ProjectId);
        }
    }
}
