using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlanner.Projects.Domain;
using ProjectPlanner.Projects.Interfaces.Application.Commands;

namespace ProjectPlanner.Projects.Application.Commands.Handlers
{
    public class UpdateProjectCommandHandler : ICommandHandler<ChangeProjectInformationCommand>
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public void Handle(ChangeProjectInformationCommand command)
        {
            var project = _projectRepository.Load(command.ProjectId);

            project.ChangeProjectInformation(command.Code, command.Name, command.Description);
            _projectRepository.Save(project);
        }
    }
}