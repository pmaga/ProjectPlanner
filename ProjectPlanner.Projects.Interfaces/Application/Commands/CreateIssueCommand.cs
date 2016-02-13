using ProjectPlanner.Cqrs.Base.CQRS.Commands.Attributes;

namespace ProjectPlanner.Projects.Interfaces.Application.Commands
{
    public class CreateIssueCommand
    {
        public string Summary { get; set; }
        public string Description { get; set; }

        [OutputCommandParameter]
        public int IssueId { get; set; }
    }
}