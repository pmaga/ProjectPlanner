using System;
using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlanner.Cqrs.Base.DDD.Application;
using ProjectPlanner.Projects.Domain;
using ProjectPlanner.Projects.Interfaces.Application.Commands;

namespace ProjectPlanner.Projects.Application.Commands.Handlers
{
    public class CreateIssueCommandHandler : ICommandHandler<CreateIssueCommand>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ISystemUser _systemUser;

        public CreateIssueCommandHandler(IProjectRepository projectRepository, ISystemUser systemUser)
        {
            _projectRepository = projectRepository;
            _systemUser = systemUser;
        }

        public void Handle(CreateIssueCommand command)
        {
            var project = _projectRepository.FindByCode(command.ProjectCode, _systemUser.UserId);

            if (project == null)
            {
                throw new InvalidOperationException($"Cannot find project {command.ProjectCode}");
            }

            project.AddIssue(command.Summary, command.Description, command.DueDate);
        }
    }
}