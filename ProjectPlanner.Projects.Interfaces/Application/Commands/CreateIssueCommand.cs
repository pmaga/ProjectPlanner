using System;
using ProjectPlanner.Cqrs.Base.CQRS.Commands.Attributes;

namespace ProjectPlanner.Projects.Interfaces.Application.Commands
{
    public class CreateIssueCommand
    {
        public string ProjectCode { get; set; }

        public string Summary { get; set; }
        public string Description { get; set; }

        [OutputCommandParameter]
        public int IssueId { get; set; }

        public DateTime? DueDate { get; set; }

        public CreateIssueCommand(string projectCode, string summary, string description, DateTime? dueDate = null)
        {
            ProjectCode = projectCode;
            Summary = summary;
            Description = description;
            DueDate = dueDate;
        }
    }
}