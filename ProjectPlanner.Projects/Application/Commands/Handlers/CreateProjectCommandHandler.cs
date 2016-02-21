using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlanner.Projects.Domain;
using ProjectPlanner.Projects.Interfaces.Application.Commands;

namespace ProjectPlanner.Projects.Application.Commands.Handlers
{
    public class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand>
    {
        public ProjectFactory ProjectFactory { get; set; }
        public IProjectRepository ProjectRepository { get; set; }

        public CreateProjectCommandHandler(ProjectFactory projectFactory, IProjectRepository projectRepository)
        {
            ProjectFactory = projectFactory;
            ProjectRepository = projectRepository;
        }

        public void Handle(CreateProjectCommand command)
        {
            var project = ProjectFactory.CreateProject(command.Code, command.Name);

            ProjectRepository.Save(project);
            command.ProjectId = project.Id;
        }
    }
}