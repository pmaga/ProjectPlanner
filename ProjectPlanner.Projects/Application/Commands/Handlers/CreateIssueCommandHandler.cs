using System;
using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlanner.Cqrs.Base.DDD.Application;
using ProjectPlanner.Cqrs.Base.DDD.Domain.Helpers;
using ProjectPlanner.Projects.Domain;
using ProjectPlanner.Projects.Interfaces.Application.Commands;

namespace ProjectPlanner.Projects.Application.Commands.Handlers
{
    public class CreateIssueCommandHandler : ICommandHandler<CreateIssueCommand>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ISystemUser _systemUser;
        private readonly InjectorHelper _injectorHelper;

        public CreateIssueCommandHandler(IProjectRepository projectRepository, ISystemUser systemUser, InjectorHelper injectorHelper)
        {
            _projectRepository = projectRepository;
            _systemUser = systemUser;
            _injectorHelper = injectorHelper;
        }

        public void Handle(CreateIssueCommand command)
        {
            var project = _projectRepository.FindByCode(command.ProjectCode, _systemUser.UserId);

            if (project == null)
            {
                throw new InvalidOperationException($"Cannot find project {command.ProjectCode}");
            }

            _injectorHelper.InjectDependencies(project);

            project.AddIssue(command.Summary, command.Description, command.DueDate);

            _projectRepository.Save(project);
        }
    }
}