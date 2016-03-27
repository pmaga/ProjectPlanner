using System;
using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlanner.Cqrs.Base.DDD.Application;
using ProjectPlanner.Cqrs.Base.DDD.Domain.Helpers;
using ProjectPlanner.Projects.Domain;
using ProjectPlanner.Projects.Interfaces.Application.Commands;

namespace ProjectPlanner.Projects.Application.Commands.Handlers
{
    public class DeleteIssueCommandHandler : ICommandHandler<DeleteIssueCommand>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly InjectorHelper _injectorHelper;
        private readonly ISystemUser _systemUser;

        public DeleteIssueCommandHandler(IProjectRepository projectRepository, InjectorHelper injectorHelper, 
            ISystemUser systemUser)
        {
            _projectRepository = projectRepository;
            _injectorHelper = injectorHelper;
            _systemUser = systemUser;
        }

        public void Handle(DeleteIssueCommand command)
        {
            var project = _projectRepository.FindByCode(command.ProjectCode, _systemUser.UserId);

            if (project == null)
            {
                throw new InvalidOperationException($"Cannot find project: {command.ProjectCode}");
            }

            _injectorHelper.InjectDependencies(project);

            project.DeleteIssue(command.IssueId);

            _projectRepository.Save(project);
        }
    }
}