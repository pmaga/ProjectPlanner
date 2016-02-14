using ProjectPlannerASP5.Base.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlannerASP5.Projects.Abstract.Application.Commands;
using ProjectPlannerASP5.Projects.Concrete.Domain;

namespace ProjectPlannerASP5.Projects.Concrete.Application.Commands.Handlers
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