using System;

namespace ProjectPlanner.Projects.Interfaces.Application.Commands
{
    public class ChangeIssueBasicInfoCommand
    {
        public string ProjectCode { get; set; }
        public int IssueId { get; set; }

        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }

        public ChangeIssueBasicInfoCommand(string projectCode, int issueId, string summary, 
            string description, DateTime? dueDate)
        {
            ProjectCode = projectCode;
            IssueId = issueId;
            Summary = summary;
            Description = description;
            DueDate = dueDate;
        }
    }
}