using ProjectPlannerASP5.Base.Cqrs.Base.CQRS.Commands.Attributes;

namespace ProjectPlannerASP5.Projects.Abstract.Application.Commands
{
    public class CreateIssueCommand
    {
        public string Summary { get; set; }
        public string Description { get; set; }

        [OutputCommandParameter]
        public int IssueId { get; set; }
    }
}