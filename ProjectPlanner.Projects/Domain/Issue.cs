using System;
using ProjectPlanner.Cqrs.Base.DDD.Domain;
using ProjectPlanner.Projects.Interfaces.Domain;
using ProjectPlanner.Projects.Domain.Interfaces;

namespace ProjectPlanner.Projects.Domain
{
    public class Issue : Entity
    {
        public int IssueNumber { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime LastChangeDate { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public IssueStatus Status { get; set; }

        public string UserName { get; set; }

        public Project Project { get; set; }

        public Issue(string summary, string description, DateTime? dueDate)
        {
            Summary = summary;
            Description = description;
            DueDate = dueDate;
        }
    }
}
