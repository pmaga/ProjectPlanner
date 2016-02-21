using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlanner.Projects.Interfaces.Application.Commands;

namespace ProjectPlanner.Projects.Application.Commands.Handlers
{
    public class CreateIssueCommandHandler : ICommandHandler<CreateIssueCommand>
    {
        public void Handle(CreateIssueCommand command)
        {
                

        }
    }
}