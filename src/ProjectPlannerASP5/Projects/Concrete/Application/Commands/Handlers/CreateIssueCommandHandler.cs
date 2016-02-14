using ProjectPlannerASP5.Base.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlannerASP5.Projects.Abstract.Application.Commands;

namespace ProjectPlannerASP5.Projects.Concrete.Application.Commands.Handlers
{
    public class CreateIssueCommandHandler : ICommandHandler<CreateIssueCommand>
    {
        public void Handle(CreateIssueCommand command)
        {
                

        }
    }
}