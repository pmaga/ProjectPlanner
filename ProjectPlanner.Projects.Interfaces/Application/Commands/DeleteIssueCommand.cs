namespace ProjectPlanner.Projects.Interfaces.Application.Commands
{
    public class DeleteIssueCommand
    {
        public string ProjectCode { get; set; }
        public int IssueId { get; set; }

        public DeleteIssueCommand(string projectCode, int issueId)
        {
            ProjectCode = projectCode;
            IssueId = issueId;
        }
    }
}